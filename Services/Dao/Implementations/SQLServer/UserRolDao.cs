using Services.Dao.Helpers;
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

namespace Services.Dao.Implementations.SQLServer.UnitOfWork
{
    public class UserRolDao : SqlTransactRepository, IUserRolDao
    {
        private List<PropertyInfo> userRoleProps;

        private List<string> userRolPropNames;

        private List<string> userRolParamNames;

        private List<string> userRolSetsNames;

        private string buildedUserRolPropNames;

        private string buildedUserRolParamNames;

        private string buildedUserRolSetsNames;

        public UserRolDao(SqlConnection context, SqlTransaction _transaction) : base(context, _transaction)
        {
            userRoleProps = typeof(UserRolRelation).GetProperties().ToList();

            userRolPropNames = userRoleProps.Select(prop => prop.Name).ToList();

            userRolParamNames = userRoleProps.Select(prop => $"@{prop.Name}").ToList();

            userRolSetsNames = userRoleProps
                            .Where(prop => prop.Name != "IdUser")
                            .Select(prop => $"{prop.Name} = @{prop.Name}")
                            .ToList();

            buildedUserRolPropNames = String.Join(", ", userRolPropNames);

            buildedUserRolParamNames = String.Join(", ", userRolParamNames);

            buildedUserRolSetsNames = String.Join(", ", userRolSetsNames);
        }

        #region Statements
        private string InsertStatement
        {
            get => $"INSERT INTO [dbo].[User] ({buildedUserRolPropNames}) VALUES ({buildedUserRolParamNames});";
        }

        private string UpdateStatement
        {
            get => $"UPDATE [dbo].[Customer] SET ({buildedUserRolSetsNames}) WHERE IdUser = @IdUser";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectByStatement
        {
            get
            {
                return $"SELECT {buildedUserRolPropNames} FROM [dbo].[Customer] WHERE";
            }
        }

        private string SelectAllStatement
        {
            get
            {
                return $"SELECT {buildedUserRolPropNames} FROM [dbo].[Customer]";
            }
        }
        private string ExistsStatement
        {
            get
            {
                return $"SELECT {buildedUserRolPropNames} FROM [dbo].[Customer]";
            }
        }
        #endregion
        public void Create(UserRolRelation entity)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(entity);
            ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }

        public void Delete(UserRolRelation entity)
        {
            throw new NotImplementedException();
        }

        public List<UserRolRelation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserRolRelation entity)
        {
            throw new NotImplementedException();
        }
        public bool Exists(UserRolRelation rel)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(rel)
                                                    .ToArray();

            string whereClause = QueryBuilder.BuildWhere(rel);

            string ExistsQuery = $"{ExistsStatement} {whereClause}";

            return ExecuteScalar(ExistsQuery, CommandType.Text, parameters) != null;
        }
    }
}
