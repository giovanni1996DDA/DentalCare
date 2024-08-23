using Services.Dao.Helpers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    internal class UserDao : SqlTransactRepository, IUserDao 
    {
        public UserDao(SqlConnection context, SqlTransaction _transaction) : base(context, _transaction)
        {

		}

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Customer] (Code, Name) VALUES (@Code, @Name); Select @@IDentity";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Customer] SET (Code = @Code, Name = @Name) WHERE IdCustomer = @IdCustomer";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdCustomer, Code, Name FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdCustomer, Code, Name FROM [dbo].[Customer]";
        }
        #endregion
        /// <summary>
        /// Crea un registro en la tabla de usuarios en la BBDD
        /// </summary>
        /// <param name="entity">Usuario a crear</param>
        public void Create(User entity)
        {
            return;
        }
        /// <summary>
        /// Elimina un registro en la tabla de usuarios de la BBDD
        /// </summary>
        /// <param name="entity">Usuario a eliminar</param>
        public void Delete(User entity)
        {
            return;
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
            return new List<User>();
        }
        /// <summary>
        /// Obtiene un registro en especifico de la tabla de usuarios en la BBDD
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns></returns>
        public User GetById(Guid id)
        {
            return new User();
        }
        /// <summary>
        /// Actualiza un registro en la tabla de usuarios de la BBDD
        /// </summary>
        /// <param name="entity">Usuario modificado</param>
        public void Update(User entity)
        {
            return;
        }
    }
}
