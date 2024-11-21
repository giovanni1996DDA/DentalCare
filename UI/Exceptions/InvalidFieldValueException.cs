using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Facade.Extensions;

namespace UI.Exceptions
{
    public class InvalidFieldValueException : Exception
    {
        public InvalidFieldValueException(string fieldName) : base($"{"El campo".Translate()} {fieldName} {"contiene un fromato inválido.".Translate()}")
        { 
        }
    }
}
