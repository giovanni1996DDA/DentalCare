﻿using Services.Dao.Helpers;
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

namespace Services.Dao.Implementations.SQLServer
{
    internal class UserPermisoDao : SqlTransactRepository, IUserPermisoDao
    {
        public UserPermisoDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(UserPermisoRelation), context, _transaction)
        {
        }
        public void Create(UserPermisoRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, rel);
            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }

        public void Delete(UserPermisoRelation entity)
        {
            throw new NotImplementedException();
        }
        public void Update(UserPermisoRelation entity)
        {
            throw new NotImplementedException();
        }
        public bool Exists(UserPermisoRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, rel);

            string whereClause = QueryBuilder.BuildWhere(Props);

            string ExistsQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(ExistsQuery, CommandType.Text, parameters) != null;
        }
        public List<UserPermisoRelation> Get(UserPermisoRelation entity, Func<PropertyInfo, bool> where = null)
        {
            throw new NotImplementedException();
        }
    }
}
