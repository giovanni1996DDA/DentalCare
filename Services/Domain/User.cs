﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class User
    {

        public Guid IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Acceso> Accesos = new List<Acceso>();
        public User(Guid idUser)
        {
            this.IdUser = idUser;
        }

    }
}
