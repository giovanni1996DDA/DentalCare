using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Services.Facade.Extensions;

namespace UI.Exceptions
{
    internal class EmptyFieldException : Exception
    {
        public EmptyFieldException(String fieldName) : base($"{"El campo".Translate()} {fieldName} {"se encuentra vacío y es obligatorio.".Translate()}")
        {
        }
    }
}
