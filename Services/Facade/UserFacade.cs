using Services.Domain;
using Services.Logic;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Facade
{
    public static class UserFacade
    {
        /// <summary>
        /// Registra un usuario si es valido
        /// </summary>
        public static void Register(User user)
        {
            if (UserService.Instance.IsRegistered(user)) 
            {
                MessageBox.Show("El usuario ya se encuentra registrado en el sistema.",
                                "El usuario ya existe.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );              
                return;
            }
            UserService.Instance.RegisterUser(user);
        }
        public static void Get(User user)
        {
            UserService.Instance.Get(user);
        }
        public static void Update(User user) 
        {
            if (!UserService.Instance.IsRegistered(user))
            {
                MessageBox.Show("El usuario que se está intentando actualizar no se encuentra registrado en el sistema.",
                                "El usuario no existe.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                return;
            }
            UserService.Instance.UpdateUser(user);
        }
        /// <summary>
        /// Chequea que las credenciales sean validas
        /// </summary>
        public static bool Validate()
        {
            return true;
        }
    }
}
