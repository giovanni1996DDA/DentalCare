using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic.Exceptions
{
    internal class NoPermissionFoundException : Exception
    {
        public NoPermissionFoundException() : base("No se encontraron permisos con el criterio especificado")
        { 
        }
    }
}
