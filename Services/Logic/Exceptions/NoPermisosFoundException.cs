using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic.Exceptions
{
    internal class NoPermisosFoundException : Exception
    {
        public NoPermisosFoundException() : base("No se encontraron permisos con los criterios de búsqueda seleccionados.") 
        { 
        }
    }
}
