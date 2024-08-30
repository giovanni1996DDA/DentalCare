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
    internal class RolPermisoDao : SqlTransactRepository, IRolPermiso
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
        public bool Exists(RolPermisoRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, rel);

            string whereClause = QueryBuilder.BuildWhere(Props);

            string ExistsQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(ExistsQuery, CommandType.Text, parameters) != null;
        }
        public List<RolPermisoRelation> Get(RolPermisoRelation entity, Func<PropertyInfo, bool> where = null)
        {
            throw new NotImplementedException();
        }
    }
}
