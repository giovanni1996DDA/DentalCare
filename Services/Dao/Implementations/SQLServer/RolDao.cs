using Services.Dao.Helpers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    internal class RolDao : SqlTransactRepository, IRolDao
    {
        public RolDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(Rol), context, _transaction)
        {
        }

        public void Create(Rol entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rol entity)
        {
            throw new NotImplementedException();
        }

        public List<Rol> Get(Rol entity, Func<PropertyInfo, bool> where = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol entity)
        {
            throw new NotImplementedException();
        }
    }
}
