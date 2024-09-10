using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer.Mappers
{
    internal static class UserPermisoRelationMapper
    {
        public static UserPermisoRelation Map(object[] values)
        {
            return new UserPermisoRelation()
            {
                IdUser = Guid.Parse($"{values[(int)UserColumns.IdUser]}"),
                IdPermiso = Guid.Parse($"{values[(int)UserColumns.IdPermiso]}"),
            };
        }
    }
    internal enum UserColumns
    {
        IdUser = 0,
        IdPermiso = 1
    }
}
