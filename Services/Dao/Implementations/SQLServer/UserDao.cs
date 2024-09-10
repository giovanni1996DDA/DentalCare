using Services.Dao.Helpers;
using Services.Dao.Implementations.Mappers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    internal class UserDao : SqlTransactRepository, IUserDao 
    {
        public UserDao(SqlConnection context, SqlTransaction _transaction) : base( typeof(User), context, _transaction)
        {
        }
        /// <summary>
        /// Crea un registro en la tabla de usuarios en la BBDD
        /// </summary>
        /// <param name="usr">Usuario a crear</param>
        public void Create(User usr)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, usr);

            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }
        public List<User> Get(User entity, Func<PropertyInfo, bool> whereCallback = null )
        {
            List<User> ret = new List<User>();

            List<PropertyInfo> filteredProps = Props.Where(prop =>
            {
                var value = prop.GetValue(entity);

                // Si whereCallback está definido, se debe cumplir
                if (whereCallback != null && !whereCallback(prop))
                {
                    return false;
                }

                // Verificar si la propiedad es Guid y si es Guid.Empty
                if (prop.PropertyType == typeof(Guid) && (Guid)value == Guid.Empty)
                {
                    return false; // Excluir las propiedades que son Guid.Empty
                }

                return true; // Incluir todas las demás propiedades
            }).ToList();

            string whereClause = QueryBuilder.BuildWhere(filteredProps, entity);

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, entity);

            string buildedGetByStatement = $"{SelectAllStatement} {whereClause}";

            using (var reader = ExecuteReader(buildedGetByStatement, CommandType.Text, parameters))
            {
                //Mientras tenga algo en mi tabla de Customers
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    ret.Add(UserMapper.Map(data));
                }
            }
            return ret;
        }
        /// <summary>
        /// Actualiza un registro en la tabla de usuarios de la BBDD
        /// </summary>
        /// <param name="entity">Usuario modificado</param>
        public void Update(User user, Func<PropertyInfo, bool> whereCallback = null)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, user);

            ExecuteNonQuery(UpdateStatement, CommandType.Text, parameters);
        }
        /// <summary>
        /// Chequea en la base de datos si existe la entidad filtrando por las propiedades definidas en el Callback. si no se define un where, sera un exact match por todos
        /// los atributos de la clase.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="whereCallback"></param>
        /// <returns></returns>
        public bool Exists(User entity, Func<PropertyInfo, bool> whereCallback = null)
        {
            List<PropertyInfo> filteredProps = Props.Where(prop =>
            {
                var value = prop.GetValue(entity);

                // Si whereCallback está definido, se debe cumplir
                if (whereCallback != null && !whereCallback(prop))
                {
                    return false;
                }

                // Verificar si la propiedad es Guid y si es Guid.Empty
                if (prop.PropertyType == typeof(Guid) && (Guid)value == Guid.Empty)
                {
                    return false; // Excluir las propiedades que son Guid.Empty
                }

                return true; // Incluir todas las demás propiedades
            }).ToList();

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, entity).ToArray();

            string whereClause = QueryBuilder.BuildWhere(filteredProps, entity);

            string finalQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(finalQuery, CommandType.Text, parameters) != null;
        }
        /// <summary>
        /// Elimina un registro en la tabla de usuarios de la BBDD
        /// </summary>
        /// <param name="entity">Usuario a eliminar</param>
        public void Delete(User user, Func<PropertyInfo, bool> whereCallback = null)
        {
            throw new NotImplementedException();
        }
    }
}
