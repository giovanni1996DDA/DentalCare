﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic.Exceptions
{
    internal class UserAlreadyRegisteredException : Exception
    {
        public UserAlreadyRegisteredException() : base("El usuario ya se encuentra registrado en el sistema.") 
        {
        }
    }
}