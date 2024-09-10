using Services.Dao.Helpers;
using Services.Dao.Implementations.Mappers;
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
    internal class RolDao : SqlTransactRepository, IRolDao
    {
        private static List<string> excludedProps = new List<string>()
        {
            "HasChildren",
            "Accesos"
        };
        public RolDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(Rol), context, _transaction, excludedProps)
        {
        }

        public void Create(Rol entity)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, entity);

            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }
        public void Delete(Rol entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Rol entity, Func<PropertyInfo, bool> whereCallback = null)
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

            return ExecuteScalar($"{ExistsStatement} {whereClause}", CommandType.Text, parameters) != null;
        }

        public List<Rol> Get(Rol entity, Func<PropertyInfo, bool> whereCallback = null)
        {
            List<Rol> ret = new List<Rol>();

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

                    ret.Add(RolMapper.Map(data));
                }
            }

            return ret;
        }
        public void Update(Rol entity)
        {
            throw new NotImplementedException();
        }
    }
}
