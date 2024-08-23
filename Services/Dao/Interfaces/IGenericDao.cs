using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Interfaces
{
    public interface IGenericDao<T>
    {
        void Create(T entity);
        List<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
    }
}
