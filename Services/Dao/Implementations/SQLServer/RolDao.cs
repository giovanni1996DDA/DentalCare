using Services.Dao.Helpers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    internal class RolDao : SqlTransactRepository, IRolDao
    {
        public RolDao(SqlConnection context, SqlTransaction _transaction) : base(context, _transaction)
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

        public List<Rol> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Rol entity)
        {
            throw new NotImplementedException();
        }
    }
}
