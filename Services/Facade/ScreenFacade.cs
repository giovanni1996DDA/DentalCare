using Services.Domain;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public class ScreenFacade
    {
        public static Screen GetOne(Screen scr)
        {
            return ScreenService.Instance.GetOne(scr);
        }
        public static List<Screen> Get(Screen scr)
        {
            return ScreenService.Instance.Get(scr);
        }
        public static void RemoveScreenFromPermiso(Permiso permiso, Screen scr)
        {
            ScreenService.Instance.RemoveScreenFromPermiso(permiso, scr);
        }

        public static void AgregarPermisoAScreen(Permiso permiso, Screen scr)
        {
            ScreenService.Instance.AgregarPermisoAScreen(permiso, scr);
        }
    }
}
