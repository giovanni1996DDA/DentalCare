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
using Services.Dao.Interfaces;
using Services.Dao.Implementations.SQLServer.Mappers;


namespace Services.Dao.Implemenations.SQLServer.Helpers
{
    public abstract class SqlTransactRepository<T> : IGenericDao<T>
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;
        protected string _TableName;

        protected List<PropertyInfo> Props = new List<PropertyInfo>();

        #region Statements
        protected string InsertStatement
        {
            get => $"INSERT INTO {_TableName}";
        }

        protected string UpdateStatement
        {
            get => $"UPDATE {_TableName}";
        }

        protected string DeleteStatement
        {
            get => $"DELETE FROM {_TableName}";
        }
        protected string SelectStatement
        {
            get
            {
                return $"SELECT {QueryBuilder.BuildColumnNames(Props)} FROM {_TableName}";
            }
        }
        #endregion

        private SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _context, _transaction);
        }

        public SqlTransactRepository(SqlConnection context, SqlTransaction _transaction, List<string> ExcludedProps = null)
        {
            this._context = context;
            this._transaction = _transaction;

            this._TableName = $"[Dbo].[{typeof(T).Name}]";

            ExcludedProps = ExcludedProps ?? new List<string>();

            Props = typeof(T).GetProperties().Where(prop => !ExcludedProps.Contains(prop.Name)).ToList();
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
        public virtual void Create(T entity)
        {
            string ColumnNames = QueryBuilder.BuildColumnNames(Props);

            string ParamNames = QueryBuilder.BuildParamNames(Props);

            SqlParameter[] parameters = QueryBuilder.BuildParams(Props, entity);

            string CompleteStatement = $"{InsertStatement} ( {ColumnNames} ) VALUES ( {ParamNames} )";

            ExecuteNonQuery(CompleteStatement, CommandType.Text, parameters);
        }

        public virtual List<T> Get(T entity, Func<PropertyInfo, bool> whereCallback = null)
        {
            List<T> ret = new List<T>();

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

            string whereClause = QueryBuilder.BuildWhere(filteredProps, entity);

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, entity);

            string buildedGetByStatement = $"{SelectStatement} {whereClause}";

            using (var reader = ExecuteReader(buildedGetByStatement, CommandType.Text, parameters))
            {
                //Mientras tenga algo en mi tabla de Customers
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    string test = $"{this.GetType().Namespace}.Mappers.{typeof(T).Name}Mapper";

                    Type mapperType = Type.GetType($"{this.GetType().Namespace}.Mappers.{typeof(T).Name}Mapper");

                    MethodInfo mapperMethod = mapperType.GetMethod("Map", BindingFlags.Static | BindingFlags.Public);

                    ret.Add((T)mapperMethod.Invoke(null, new object[] { data }));
                }
            }
            return ret;
        }
        public virtual bool Exists(T entity, Func<PropertyInfo, bool> whereCallback = null)
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

            string whereClause = QueryBuilder.BuildWhere(filteredProps, entity);

            string finalQuery = $"{SelectStatement} {whereClause}";

            return ExecuteScalar(finalQuery, CommandType.Text, parameters) != null;
        }
        public virtual void Update(T entity, Func<PropertyInfo, bool> whereCallback = null)
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

            string set = QueryBuilder.BuildSet(filteredProps, entity);

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, entity);

            ExecuteNonQuery(UpdateStatement, CommandType.Text, parameters);
        }
        public virtual void Delete(T entity, Func<PropertyInfo, bool> whereCallback = null)
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

            string whereClause = QueryBuilder.BuildWhere(filteredProps, entity);

            SqlParameter[] parameters = QueryBuilder.BuildParams(filteredProps, entity);

            string buildedGetByStatement = $"{DeleteStatement} {whereClause}";

            ExecuteNonQuery(buildedGetByStatement, CommandType.Text, parameters);
        }
    }
}
