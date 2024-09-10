using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class UserPermisoRelation
    {
        public Guid IdUser { get; set; }
        public Guid IdPermiso { get; set; }
    }
}
