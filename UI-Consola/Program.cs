﻿using Services.Dao.Factory;
using Services.Domain;
using Services.Facade;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rol rol = new Rol()
            {
                Nombre = "rol 1",
                Descripcion = "rol 1"
            };

            Permiso permiso = new Permiso()
            {
                Nombre = "Permiso 1",
                Modulo = (int)Modulo.UI
            };

            AccesoService.Instance.CreateOrUpdate(permiso);

            rol.Add(permiso);

            permiso = new Permiso()
            {
                Nombre = "Permiso 2",
                Modulo = (int)Modulo.UseCases
            };

            AccesoService.Instance.CreateOrUpdate(permiso);

            rol.Add(permiso);

            AccesoService.Instance.CreateOrUpdate(rol);

            User user = new User()
            {
                UserName = "pito",
                Password = "Password$1",
                Accesos = new List<Acceso>()
                {
                    rol
                }
            };

            UserFacade.Register(user);

            List<User> getUser = UserFacade.Get(new User());
        }
    }
}