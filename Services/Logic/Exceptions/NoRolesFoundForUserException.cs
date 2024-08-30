using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Services.Logic.Exceptions
{
    internal class NoRolesFoundForUserException : Exception
    {
        public NoRolesFoundForUserException(string uname) : base($"El usuario {uname} no posee ningun rol asignado.") 
        { 
        }
    }
}
