using Services.Dao.Helpers;
using Services.Dao.Implementations.SQLServer.Mappers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    internal class PermisoDao : SqlTransactRepository, IPermisoDao
    {
        private static List<string> excludedProps = new List<string>()
        {
            "HasChildren",
            "Accesos"
        };
        public PermisoDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(Permiso), context, _transaction, excludedProps)
        {
        }
        public void Create(Permiso entity)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, entity);

            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }

        public void Delete(Permiso entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Permiso entity, Func<PropertyInfo, bool> whereCallback = null)
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

            string whereClause = QueryBuilder.BuildWhere(filteredProps);

            string finalQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(finalQuery, CommandType.Text, parameters) != null;
        }

        public List<Permiso> Get(Permiso entity, Func<PropertyInfo, bool> whereCallback = null)
        {
            List<Permiso> ret = new List<Permiso>();

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

            string whereClause = QueryBuilder.BuildWhere(filteredProps);

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, entity);

            string buildedGetByStatement = $"{SelectAllStatement} {whereClause}";

            using (var reader = ExecuteReader(buildedGetByStatement, CommandType.Text, parameters))
            {
                //Mientras tenga algo en mi tabla de Customers
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    ret.Add(PermisoMapper.Map(data));
                }
            }
            return ret;
        }

        public void Update(Permiso entity)
        {
            throw new NotImplementedException();
        }
    }
}
