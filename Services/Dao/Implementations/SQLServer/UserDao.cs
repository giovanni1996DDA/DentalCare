using Services.Dao.Helpers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    internal class UserDao : SqlTransactRepository, IUserDao 
    {
        private List<PropertyInfo> userProps = new List<PropertyInfo>();

        private List<string> userPropNames;

        private List<string> userParamNames;

        private List<string> userSetsNames;

        private string buildedUserPropNames;

        private string buildedUserParamNames;

        private string buildedUserSetsNames;

        public UserDao(SqlConnection context, SqlTransaction _transaction) : base(context, _transaction)
        {
            userProps = typeof(User).GetProperties().ToList();

            userPropNames = userProps.Select(prop => prop.Name).ToList();

            userParamNames = userProps.Select(prop => $"@{prop.Name}").ToList();

            userSetsNames = userProps
                            .Where(prop => prop.Name != "IdUser")
                            .Select(prop => $"{prop.Name} = @{prop.Name}")
                            .ToList();

            buildedUserPropNames = String.Join(", ", userPropNames);

            buildedUserParamNames = String.Join(", ", userParamNames);

            buildedUserSetsNames = String.Join(", ", userSetsNames);
        }

        #region Statements
        private string InsertStatement
        {
            get => $"INSERT INTO [dbo].[User] ({buildedUserPropNames}) VALUES ({buildedUserParamNames});";
        }

        private string UpdateStatement
        {
            get => $"UPDATE [dbo].[Customer] SET ({buildedUserSetsNames}) WHERE IdUser = @IdUser";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectByStatement
        {
            get
            {
                return $"SELECT {buildedUserPropNames} FROM [dbo].[Customer] WHERE"; 
            }
        }

        private string SelectAllStatement
        {
            get 
            {
                return $"SELECT {buildedUserPropNames} FROM [dbo].[Customer]";
            }
        }
        private string ExistsStatement
        {
            get
            {
                return $"SELECT {buildedUserPropNames} FROM [dbo].[Customer] WHERE IdUser = @IdUser";
            }
        }
        #endregion
        /// <summary>
        /// Crea un registro en la tabla de usuarios en la BBDD
        /// </summary>
        /// <param name="entity">Usuario a crear</param>
        public void Create(User entity)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(entity);

            object returnValue = ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);
        }
        /// <summary>
        /// Obtiene todos los usuarios que hay guardados en la tabla de usuarios de la BBDD
        /// <remarks>
        /// Puede provocar problemas de prformance.
        /// </remarks>
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            List<User> users = null;

            using (var reader = ExecuteReader(SelectAllStatement, CommandType.Text))
            {
                //Mientras tenga algo en mi tabla de Customers
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    //users.Add(CustomerMapper.Current.Fill(data));
                }
            }

            return users;
        }
        /// <summary>
        /// Obtiene un registro en especifico de la tabla de usuarios en la BBDD
        /// </summary>
        /// <param name="user">Usuario armado con los atributos a buscar</param>
        /// <returns></returns>
        public List<User> Get(User user)
        {
            List<User> ret = null;

            string whereClause = QueryBuilder.BuildWhere(user);

            SqlParameter[] parameters = QueryBuilder.BuildParams(user);

            string buildedGetByStatement = $"{SelectByStatement} {whereClause}";

            using (var reader = ExecuteReader(buildedGetByStatement, CommandType.Text, parameters))
            {
                //Mientras tenga algo en mi tabla de Customers
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    //users.Add(CustomerMapper.Current.Fill(data));
                }
            }

            return ret;
        }
        /// <summary>
        /// Actualiza un registro en la tabla de usuarios de la BBDD
        /// </summary>
        /// <param name="entity">Usuario modificado</param>
        public void Update(User user)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(user);

            object returnValue = ExecuteNonQuery(UpdateStatement, CommandType.Text, parameters);
        }
        public bool Exists(User user)
        {
            SqlParameter[] parameters = QueryBuilder.BuildParams(user)
                                        .Where(param => param.ParameterName == "@IdUser")
                                        .ToArray();
            
            return ExecuteScalar(ExistsStatement, CommandType.Text, parameters) != null;
        }
        /*private string BuildWhere(User user)
        {
            return "WHERE " + String.Join(", ", userProps
                                     .Where(prop => prop.GetValue(user) != null)
                                     .Select(prop => $"{prop.Name} = @{prop.Name}")
                                     .ToList()
                                     );
        }

        private SqlParameter[] BuildParams(User user)
        {
             return userProps
                    .Where(prop => prop.GetValue(user) != null)
                    .Select(prop =>
                    {
                        return new SqlParameter($"@{prop.Name}", $"{prop.GetValue(user)}");
                    })
                    .ToArray();
        }*/
        /// <summary>
        /// Elimina un registro en la tabla de usuarios de la BBDD
        /// </summary>
        /// <param name="entity">Usuario a eliminar</param>
        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
