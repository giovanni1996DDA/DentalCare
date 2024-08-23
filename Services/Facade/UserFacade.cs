using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class UserFacade
    {
        /// <summary>
        /// Registra un usuario si es valido
        /// </summary>
        public static void Register()
        {

        }
        /// <summary>
        /// Chequea que las credenciales sean validas
        /// </summary>
        public static bool Validate()
        {
            return true;
        }
        /// <summary>
        /// Valida que el usuario solicitado tenga acceso a la accion que se esta solicitando
        /// </summary>
        /// <param name="user"></param>
        /// <param name="acceso"></param>
        /// <returns></returns>
        public static bool HasAccess(User user, Acceso acceso) 
        {
            return true;
        }
    }
}
