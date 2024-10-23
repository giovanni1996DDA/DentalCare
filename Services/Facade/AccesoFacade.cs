using Services.Domain;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class AccesoFacade
    {
        public static Acceso GetOne(Acceso acc)
        {
            return AccesoService.Instance.GetOne(acc);
        }

        public static Rol GetOne(Rol rol)
        {
            return AccesoService.Instance.GetOne(rol);
        }
    }
}
