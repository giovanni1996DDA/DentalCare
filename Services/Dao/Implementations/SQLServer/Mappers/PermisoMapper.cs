using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer.Mappers
{
    internal class PermisoMapper
    {
        public static Permiso Map(object[] values)
        {
            return new Permiso()
            {
                Id = Guid.Parse($"{values[(int)PermisoColumns.Id]}"),
                Nombre = (string)values[(int)PermisoColumns.Nombre],
                Modulo = (int)PermisoColumns.Modulo,
            };
        }
    }
    internal enum PermisoColumns
    {
        Modulo = 0,
        Id = 1,
        Nombre = 2
    }
}
