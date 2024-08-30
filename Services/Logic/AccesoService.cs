using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    internal class AccesoService
    {
        private static AccesoService instance = new AccesoService();
        public static AccesoService Instance { get { return instance; } }
        private AccesoService()
        {
        }

        public List<Acceso> getAccesos(User user)
        {
            List<Acceso> returning = new List<Acceso>();

            returning.AddRange( RolService.Instance.GetByUser(user) );

            return returning;
        }
    }
}
