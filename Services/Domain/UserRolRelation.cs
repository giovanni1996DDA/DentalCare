using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class UserRolRelation
    {
        public Guid IdUser { get; set; }
        public Guid IdRol { get; set; }
    }
}
