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

namespace Services.Dao.Implementations.SQLServer
{
    internal class RolRolDao : SqlTransactRepository, IRolRolDao
    {
        public RolRolDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(RolRolRelation), context, _transaction)
        {
        }
        public void Create(RolRolRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, rel);
            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }

        public void Delete(RolRolRelation entity)
        {
            throw new NotImplementedException();
        }
        public void Update(RolRolRelation entity)
        {
            throw new NotImplementedException();
        }
        public bool Exists(RolRolRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, rel);

            string whereClause = QueryBuilder.BuildWhere(Props);

            string ExistsQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(ExistsQuery, CommandType.Text, parameters) != null;
        }

        public List<RolRolRelation> Get(RolRolRelation entity, Func<PropertyInfo, bool> where = null)
        {
            throw new NotImplementedException();
        }
    }
}
