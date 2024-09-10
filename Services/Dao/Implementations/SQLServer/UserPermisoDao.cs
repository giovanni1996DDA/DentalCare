using Services.Dao.Helpers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Services.Dao.Implementations.Mappers;
using Services.Dao.Implementations.SQLServer.Mappers;

namespace Services.Dao.Implementations.SQLServer
{
    internal class UserPermisoDao : SqlTransactRepository, IUserPermisoDao
    {
        public UserPermisoDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(UserPermisoRelation), context, _transaction)
        {
        }
        public void Create(UserPermisoRelation relation)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, relation);
            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }

        public void Delete(UserPermisoRelation entity, Func<PropertyInfo, bool> whereCallback = null)
        {
            throw new NotImplementedException();
        }
        public void Update(UserPermisoRelation entity, Func<PropertyInfo, bool> whereCallback = null)
        {
            throw new NotImplementedException();
        }
        public bool Exists(UserPermisoRelation entity, Func<PropertyInfo, bool> whereCallback = null)
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
        public List<UserPermisoRelation> Get(UserPermisoRelation entity, Func<PropertyInfo, bool> whereCallback = null)
        {
            List<UserPermisoRelation> ret = new List<UserPermisoRelation>();

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

                    ret.Add(UserPermisoRelationMapper.Map(data));
                }
            }

            return ret;
        }
    }
}
