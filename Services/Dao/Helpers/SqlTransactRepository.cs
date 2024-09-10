using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Specialized;
using System.Configuration;
using Services.Domain;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Services.Dao.Implementations.SQLServer;


namespace Services.Dao.Helpers
{
    public abstract class SqlTransactRepository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;
        protected string _TableName;

        protected List<PropertyInfo> Props = new List<PropertyInfo>();

        protected List<string> PropNames;

        protected List<string> ParamNames;

        protected List<string> SetsNames;

        protected string BuildedPropNames;

        protected string BuildedParamNames;

        protected string BuildedSetsNames;

        #region Statements
        protected string InsertStatement
        {
            get => $"INSERT INTO {_TableName} ({BuildedPropNames} ) VALUES ( {BuildedParamNames});";
        }

        protected string UpdateStatement
        {
            get => $"UPDATE {_TableName} SET {BuildedSetsNames}";
        }

        protected string DeleteStatement
        {
            get => $"DELETE FROM {_TableName}";
        }
        protected string SelectAllStatement
        {
            get
            {
                return $"SELECT {BuildedPropNames} FROM {_TableName}";
            }
        }
        protected string ExistsStatement
        {
            get
            {
                return $"SELECT {BuildedPropNames} FROM {_TableName}";
            }
        }
        #endregion

        private SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _context, _transaction);
        }

        public SqlTransactRepository(Type daoObjectType, SqlConnection context, SqlTransaction _transaction, List<string> ExcludedProps = null)
        {
            this._context = context;
            this._transaction = _transaction;

            this._TableName = $"[Dbo].[{((NameValueCollection)ConfigurationManager.GetSection("DbNames"))[this.GetType().Name]}]";

            ExcludedProps = ExcludedProps ?? new List<string>();

            Props = daoObjectType.GetProperties().Where(prop => !ExcludedProps.Contains(prop.Name)).ToList();

            PropNames = Props.Select(prop => prop.Name).ToList();

            ParamNames = Props.Select(prop => $"@{prop.Name}").ToList();

            SetsNames = Props
                            .Where(prop => prop.Name != "IdUser")
                            .Select(prop => $"{prop.Name} = @{prop.Name}")
                            .ToList();

            BuildedPropNames = String.Join(", ", PropNames);

            BuildedParamNames = String.Join(", ", ParamNames);

            BuildedSetsNames = String.Join(", ", SetsNames);
        }

        protected Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            CheckNullables(parameters);

            using (var cmd = CreateCommand(commandText))
            {
                //AGREGADO
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                //AGREGADO

                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        private void CheckNullables(SqlParameter[] parameters)
        {
            foreach (SqlParameter item in parameters)
            {
                if (item.SqlValue == null)
                {
                    item.SqlValue = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// Set the connection, command, and then execute the command and only return one value.
        /// </summary>
        protected Object ExecuteScalar(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (var cmd = CreateCommand(commandText))
            {
                cmd.CommandType = commandType;

                cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Set the connection, command, and then execute the command with query and return the reader.
        /// </summary>
        protected SqlDataReader ExecuteReader(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (var cmd = CreateCommand(commandText))
            {
                cmd.CommandType = commandType;

                cmd.Parameters.AddRange(parameters);
                // When using CommandBehavior.CloseConnection, the connection will be closed when the 
                // IDataReader is closed.
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}
