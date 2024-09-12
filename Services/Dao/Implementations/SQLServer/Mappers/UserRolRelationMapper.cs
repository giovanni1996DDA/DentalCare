using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer.Mappers
{
    internal static class UserRolRelationMapper
    {
        public static UserRolRelation Map(object[] values)
        {
            return new UserRolRelation()
            {
                IdUser = Guid.Parse($"{values[(int)UserRolColumns.IdUser]}"),
                IdRol = Guid.Parse($"{values[(int)UserRolColumns.IdRol]}"),
            };
        }
    }

    internal enum UserRolColumns
    {
        IdUser = 0,
        IdRol = 1,
    }
}
