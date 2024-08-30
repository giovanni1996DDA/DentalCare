using Services.Dao.Factory;
using Services.Domain;
using Services.Facade;
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
            List<Acceso> accesos = new List<Acceso>() { 
                                                            new Permiso()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                Nombre = "Test",
                                                                Modulo = Modulo.UI
                                                            },
                                                            new Permiso()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                Nombre = "Test 2",
                                                                Modulo = Modulo.UseCases
                                                            },

                                                        };

            User usr = new User(){
                                   IdUser = Guid.NewGuid(),
                                   Password = "pito",
                                   UserName = "Test",
                                   Accesos = accesos
            };

            UserFacade.Get(usr);
        }
    }
}
