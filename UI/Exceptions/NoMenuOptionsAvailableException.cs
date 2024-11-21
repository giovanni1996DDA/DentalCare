using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Facade.Extensions;


namespace UI.Exceptions
{
    public class NoMenuOptionsAvailableException : Exception
    {
        public NoMenuOptionsAvailableException(string Uname) : base($"{"No se encontraron menús disponibles para el usuario".Translate()} {Uname}.") 
        { 
        }
    }
}
