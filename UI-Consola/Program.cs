using Services.Dao.Factory;
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

            List<Acceso> accesos = new List<Acceso>();

            Permiso permiso = new Permiso{
                                            Id = Guid.NewGuid(),
                                            Nombre = "Test permiso 1",
                                            Modulo = 1
                                        };

            AccesoService.Instance.CreateOrUpdate(permiso);

            accesos.Add(permiso);

            permiso = new Permiso{
                                    Id = Guid.NewGuid(),
                                    Nombre = "Test permiso 2",
                                    Modulo = 3
                                };

            AccesoService.Instance.CreateOrUpdate(permiso);

            accesos.Add(permiso);


            permiso = new Permiso
            {
                Id = Guid.NewGuid(),
                Nombre = "Test permiso 2",
                Modulo = 2
            };

            AccesoService.Instance.CreateOrUpdate(permiso);

            Rol rol = new Rol
            {
                Id = Guid.NewGuid(),
                Nombre = "Test rol",
                Descripcion = "Test rol"
            };

            rol.Add(permiso);

            AccesoService.Instance.CreateOrUpdate(rol);

            accesos.Add(rol);

            User usr = new User(){
                                   Password = "pito",
                                   UserName = "Test",
                                   Accesos = accesos
            };

            UserFacade.Register(usr);

            usr = new User()
            {
                Password = "pito",
                UserName = "Test",
            };

            List<User> user = UserFacade.Get(usr);

            Console.WriteLine(user.Count);
        }
    }
}
