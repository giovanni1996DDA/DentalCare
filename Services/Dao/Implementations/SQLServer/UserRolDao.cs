using Services.Dao.Helpers;
using Services.Dao.Implementations.Mappers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    public class UserRolDao : SqlTransactRepository, IUserRolDao
    {
        public UserRolDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(UserRolRelation), context, _transaction)
        {
        }
        public void Create(UserRolRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, rel);
            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }

        public void Delete(UserRolRelation entity)
        {
            throw new NotImplementedException();
        }
        public void Update(UserRolRelation entity)
        {
            throw new NotImplementedException();
        }
        public bool Exists(UserRolRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, rel);

            string whereClause = QueryBuilder.BuildWhere(Props);

            string ExistsQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(ExistsQuery, CommandType.Text, parameters) != null;
        }
        public List<UserRolRelation> Get(UserRolRelation entity = null, Func<PropertyInfo, bool> where = null)
        {
            entity = entity ?? new UserRolRelation();

            List<UserRolRelation> ret = null;

            List<PropertyInfo> filteredProps = where == null ? Props : Props.Where(where).ToList();

            string whereClause = QueryBuilder.BuildWhere(filteredProps);

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, entity);

            string buildedGetByStatement = $"{SelectAllStatement} {whereClause}";

            using (var reader = ExecuteReader(buildedGetByStatement, CommandType.Text, parameters))
            {
                //Mientras tenga algo en mi tabla de Customers
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    //ret.Add(RolMapper.Map(data));
                }
            }

            return ret;
        }
    }
}
