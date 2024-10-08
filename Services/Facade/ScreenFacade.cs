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
    }
}
