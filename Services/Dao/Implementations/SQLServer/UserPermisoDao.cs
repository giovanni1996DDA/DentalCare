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

namespace Services.Dao.Implementations.SQLServer
{
    internal class UserPermisoDao : SqlTransactRepository, IUserPermisoDao
    {
        private List<PropertyInfo> userPermisoProps;

        private List<string> userPermisoPropNames;

        private List<string> userPermisoParamNames;

        private string buildedUserPermisoPropNames;

        private string buildedUserPermisoParamNames;

        public UserPermisoDao(SqlConnection context, SqlTransaction _transaction) : base(context, _transaction)
        {
            userPermisoProps = typeof(UserPermisoRelation).GetProperties().ToList();

            userPermisoPropNames = userPermisoProps.Select(prop => prop.Name).ToList();

            userPermisoParamNames = userPermisoProps.Select(prop => $"@{prop.Name}").ToList();

            buildedUserPermisoPropNames = String.Join(", ", userPermisoPropNames);

            buildedUserPermisoParamNames = String.Join(", ", userPermisoParamNames);
        }

        #region Statements
        private string InsertStatement
        {
            get => $"INSERT INTO [dbo].[User] ({buildedUserPermisoPropNames}) VALUES ({buildedUserPermisoParamNames});";
        }

        private string UpdateStatement
        {
            get => $"UPDATE [dbo].[Customer] SET ({buildedUserPermisoSetsNames})";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectByStatement
        {
            get
            {
                return $"SELECT {buildedUserPermisoPropNames} FROM [dbo].[Customer]";
            }
        }

        private string SelectAllStatement
        {
            get
            {
                return $"SELECT {buildedUserPermisoPropNames} FROM [dbo].[Customer]";
            }
        }
        private string ExistsStatement
        {
            get
            {
                return $"SELECT {buildedUserPermisoPropNames} FROM [dbo].[Customer]";
            }
        }
        #endregion
        public void Create(UserPermisoRelation entity)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(entity);
            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }

        public void Delete(UserPermisoRelation entity)
        {
            throw new NotImplementedException();
        }

        public List<UserPermisoRelation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserPermisoRelation entity)
        {
            throw new NotImplementedException();
        }
        public bool Exists(UserPermisoRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(rel)
                                                    .ToArray();

            string whereClause = QueryBuilder.BuildWhere(rel);

            string ExistsQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(ExistsQuery, CommandType.Text, parameters) != null;
        }
    }
}
