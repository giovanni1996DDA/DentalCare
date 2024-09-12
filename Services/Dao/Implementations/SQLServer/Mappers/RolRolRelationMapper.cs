using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer.Mappers
{
    internal class RolRolRelationMapper
    {
        public static RolRolRelation Map(object[] values)
        {
            return new RolRolRelation()
            {
                FatherId = Guid.Parse($"{values[(int)RolRolColumns.FatherId]}"),
                ChildId = Guid.Parse($"{values[(int)RolRolColumns.ChildId]}"),
            };
        }
    }

    internal enum RolRolColumns
    {
        FatherId = 0,
        ChildId = 1,
    }
}
