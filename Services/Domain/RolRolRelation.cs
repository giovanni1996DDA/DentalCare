using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    internal class RolRolRelation
    {
        public Rol FatherRole { get; set; }
        public Rol ChildRole { get; set; }
    }
}
