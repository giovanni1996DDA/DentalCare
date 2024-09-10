using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer.Mappers
{
    internal static class RolMapper
    {
        public static Rol Map(object[] values)
        {
            return new Rol()
            {
                Id = Guid.Parse($"{values[(int)RolColumns.Id]}"),
                Nombre = (string)values[(int)RolColumns.Nombre],
                Descripcion = (string)values[(int)RolColumns.Descripcion],
            };
        }
    }

    internal enum RolColumns
    {
        Descripcion = 0,
        Id = 1,
        Nombre = 2
        
    }
}
