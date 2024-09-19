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
    /// <summary>
    /// Proporciona una fachada para la gestión de usuarios, permitiendo registrar, obtener y actualizar usuarios de manera simplificada.
    /// </summary>
    public static class UserFacade
    {
        /// <summary>
        /// Registra un usuario en el sistema si es válido.
        /// </summary>
        /// <param name="user">El objeto User que representa el usuario a registrar.</param>
        /// <exception cref="UserAlreadyRegisteredException">Se lanza si el usuario ya está registrado.</exception>
        /// <exception cref="Exception">Se lanza en caso de cualquier otra excepción durante el registro.</exception>
        public static void Register(User user)
        {
            try
            {
                UserService.Instance.RegisterUser(user);
            }
            catch (UserAlreadyRegisteredException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Obtiene una lista de usuarios que coinciden con los criterios especificados en el objeto User.
        /// </summary>
        /// <param name="user">El objeto User que contiene los criterios de búsqueda.</param>
        /// <returns>Una lista de usuarios que coinciden con los criterios especificados.</returns>
        public static List<User> Get(User user)
        {
            return UserService.Instance.Get(user);
        }
        public static void Login(User user)
        {
            UserService.Instance.Login(user);
        }
        /// <summary>
        /// Actualiza la información de un usuario en el sistema si está registrado.
        /// Muestra un mensaje de error si el usuario no está registrado.
        /// </summary>
        /// <param name="user">El objeto User que contiene la información actualizada del usuario.</param>
        public static void Update(User user)
        {
            UserService.Instance.UpdateUser(user);
        }

        /// <summary>
        /// Verifica si las credenciales del usuario son válidas.
        /// Actualmente, siempre devuelve true.
        /// </summary>
        /// <returns>True si las credenciales son válidas; de lo contrario, false.</returns>
        public static bool Validate()
        {
            return true;
        }
    }
}
