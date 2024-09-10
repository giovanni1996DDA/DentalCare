using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Interfaces
{
    public interface IGenericDao<T>
    {
        void Create(T entity);
        /// <summary>
        /// Obtiene los registros de la tabla en la BBDD en base a los filtros especificados
        /// </summary>
        /// <param name="entity">La entidad prototipo por la cual se va a realizar la busqueda</param>
        /// <param name="whereCallback"> los atributos de la entidad prototipo por la cual se va a realizar la busqueda. por default son todos los atributos.</param>
        /// <returns></returns>
        List<T> Get(T entity, Func<PropertyInfo, bool> whereCallback = null);
        bool Exists(T entity, Func<PropertyInfo, bool> whereCallback = null);
        void Update(T entity);
        void Delete(T entity);
    }
}
