using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    internal class RolPermisoRelation
    {
        public Rol Role { get; set; }
        public Permiso Permiso { get; set; }
    }
}
