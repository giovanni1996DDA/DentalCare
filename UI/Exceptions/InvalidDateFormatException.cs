using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Facade.Extensions;

namespace UI.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException() : base("El formato de la fecha es incorrecto. El formato debe ser: DDMMYYYY o DD/MM/YYYY.".Translate()) 
        {
        }
    }
}
