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

            Guid id = Guid.NewGuid();

            List<Acceso> accesos = new List<Acceso>();


            Rol rol = new Rol
            {
                Id = id,
                Nombre = "Test rol",
                Descripcion = "Test rol"
            };

            Permiso permiso = new Permiso{
                                            Id = Guid.NewGuid(),
                                            Nombre = "Test permiso 1",
                                            Modulo = 1
                                        };

            AccesoService.Instance.CreateOrUpdate(permiso);
            rol.Add(permiso);

            Permiso permiso2 = new Permiso{
                                    Id = Guid.NewGuid(),
                                    Nombre = "Test permiso 2",
                                    Modulo = 3
                                };

            AccesoService.Instance.CreateOrUpdate(permiso2);
            rol.Add(permiso2);

            Permiso permiso3 = new Permiso
            {
                Id = Guid.NewGuid(),
                Nombre = "Test permiso 3",
                Modulo = 2
            };

            AccesoService.Instance.CreateOrUpdate(permiso3);
            rol.Add(permiso3);

            AccesoService.Instance.CreateOrUpdate(rol);

            Rol rolNew = AccesoService.Instance.Get( new Rol { Id = id }).Select(p => (Rol)p ).ToList().FirstOrDefault();

            Permiso permisoDel = (Permiso) rol.Accesos[1];

            rolNew.Remove(permisoDel);

            rolNew.Nombre = "Lo cambie y funciona gucci";

            AccesoService.Instance.CreateOrUpdate(rolNew);

            rolNew = null;

            rolNew = AccesoService.Instance.Get(new Rol { Id = id }).Select(p => (Rol)p).ToList().FirstOrDefault();


        }
    }
}
