using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Dao.Helpers;
using Services.Dao.Interfaces;
using System.Reflection;
using Services.Dao.Implementations.SQLServer.Mappers;

namespace Services.Dao.Implementations.SQLServer
{
    public class RolPermisoDao : SqlTransactRepository, IRolPermisoDao
    {
        public RolPermisoDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(RolPermisoRelation), context, _transaction)
        {
        }
        public void Create(RolPermisoRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, rel);
            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }

        public void Delete(RolPermisoRelation entity)
        {
            throw new NotImplementedException();
        }
        public void Update(RolPermisoRelation entity)
        {
            throw new NotImplementedException();
        }
        public List<RolPermisoRelation> Get(RolPermisoRelation entity, Func<PropertyInfo, bool> whereCallback = null)
        {
            List<RolPermisoRelation> ret = new List<RolPermisoRelation>();

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

                    ret.Add(RolPermisoMapper.Map(data));
                }
            }

            return ret;
        }

        public bool Exists(RolPermisoRelation entity, Func<PropertyInfo, bool> whereCallback = null)
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

        public bool HasPermisos(RolPermisoRelation relation)
        {
            Func<PropertyInfo, bool>  whereCallback = (prop => prop.Name == "IdRol");

            List<PropertyInfo> filteredProps = Props.Where(whereCallback).ToList();

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, relation).ToArray();

            string whereClause = QueryBuilder.BuildWhere(filteredProps);

            string finalQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(finalQuery, CommandType.Text, parameters) != null;
        }
    }
}
