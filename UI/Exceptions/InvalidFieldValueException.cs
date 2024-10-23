using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Exceptions
{
    public class InvalidFieldValueException : Exception
    {
        public InvalidFieldValueException(string fieldName) : base($"El campo {fieldName} contiene un fromato inválido.")
        { 
        }
    }
}
