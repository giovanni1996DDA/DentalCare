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
        public List<User> Get(User usr, Func<PropertyInfo, bool> where = null )
        {
            List<User> ret = null;

            List<PropertyInfo> filteredProps = where == null ? Props : Props.Where(where).ToList();

            string whereClause = QueryBuilder.BuildWhere(filteredProps);

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, usr);

            string buildedGetByStatement = $"{SelectAllStatement} {whereClause}";

            using (var reader = ExecuteReader(buildedGetByStatement, CommandType.Text, parameters))
            {
                //Mientras tenga algo en mi tabla de Customers
                if (reader.Read())
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
        public void Update(User user)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, user);

            object returnValue = ExecuteNonQuery(UpdateStatement, CommandType.Text, parameters);
        }
        public bool Exists(User user)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams( Props.Where(prop => prop.Name == "IdUser").ToList() , user).ToArray();
            
            return ExecuteScalar(ExistsStatement, CommandType.Text, parameters) != null;
        }
        /*private string BuildWhere(User user)
        {
            return "WHERE " + String.Join(", ", userProps
                                     .Where(prop => prop.GetValue(user) != null)
                                     .Select(prop => $"{prop.Name} = @{prop.Name}")
                                     .ToList()
                                     );
        }

        private SqlParameter[] BuildParams(User user)
        {
             return userProps
                    .Where(prop => prop.GetValue(user) != null)
                    .Select(prop =>
                    {
                        return new SqlParameter($"@{prop.Name}", $"{prop.GetValue(user)}");
                    })
                    .ToArray();
        }*/
        /// <summary>
        /// Elimina un registro en la tabla de usuarios de la BBDD
        /// </summary>
        /// <param name="entity">Usuario a eliminar</param>
        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
