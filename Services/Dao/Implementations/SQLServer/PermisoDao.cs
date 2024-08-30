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
    internal class PermisoDao : SqlTransactRepository, IPermisoDao
    {
        public PermisoDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(Permiso), context, _transaction)
        {
        }
        public void Create(Permiso entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Permiso entity)
        {
            throw new NotImplementedException();
        }

        public List<Permiso> Get(Permiso entity, Func<PropertyInfo, bool> where = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Permiso entity)
        {
            throw new NotImplementedException();
        }
    }
}
