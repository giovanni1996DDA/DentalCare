using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer.Mappers
{
    internal class RolPermisoRelationMapper
    {
        public static RolPermisoRelation Map(object[] values)
        {
            return new RolPermisoRelation()
            {
                IdRol = Guid.Parse($"{values[(int)RolPermisoColumns.IdRol]}"),
                IdPermiso = Guid.Parse($"{values[(int)RolPermisoColumns.IdPermiso]}"),
            };
        }
    }

    internal enum RolPermisoColumns
    {
        IdRol = 0,
        IdPermiso = 1,
    }
}
