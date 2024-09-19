using Services.Dao.Factory;
using Services.Dao.Interfaces;
using Services.Domain;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    /// <summary>
    /// Servicio para gestionar usuarios en el sistema.
    /// Proporciona funcionalidad para registrar, actualizar, validar y obtener usuarios.
    /// </summary>
    public class UserService
    {
        #region Singleton
        /// <summary>
        /// Instancia única de la clase UserService (patrón Singleton).
        /// </summary>
        private static readonly UserService instance = new UserService();

        /// <summary>
        /// Obtiene la instancia única del servicio de usuarios.
        /// </summary>
        public static UserService Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Constructor privado para implementar el patrón Singleton.
        /// </summary>
        private UserService() { }
        #endregion

        /// <summary>
        /// Registra un usuario en la base de datos.
        /// </summary>
        /// <param name="user">El objeto usuario a registrar.</param>
        /// <exception cref="InvalidUserException">Si los datos del usuario no son válidos.</exception>
        /// <exception cref="UserAlreadyRegisteredException">Si el nombre de usuario ya está registrado.</exception>
        public void RegisterUser(User user)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (!isValid(user, results))
                throw new InvalidUserException(results.FirstOrDefault()?.ErrorMessage);

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;

                // Verifica si existe un usuario con ese UserName
                if (userRepo.Exists(new User { UserName = user.UserName }))
                    throw new UserAlreadyRegisteredException();
            }

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;

                userRepo.Create(user);

                foreach (Acceso access in user.Accesos)
                {
                    AccesoService.Instance.CreateRelation(context, user, access);
                }

                context.SaveChanges();
            }
        }
        public void Login(User user) 
        {
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;

                // Valida la existencia de un usuario con esa contraseña
                if (!userRepo.Exists(user))
                    throw new InvalidUserLoginException();

                user = userRepo.GetOne(user);

                SessionManager.SetUser(user);
            }
        }

        /// <summary>
        /// Obtiene una lista de usuarios que cumplen con los criterios del objeto de búsqueda.
        /// </summary>
        /// <param name="user">Objeto usuario con los criterios de búsqueda.</param>
        /// <returns>Lista de usuarios que coinciden con los criterios.</returns>
        /// <exception cref="NoUsersFoundException">Si no se encuentran usuarios que coincidan con los criterios.</exception>
        public List<User> Get(User user)
        {
            List<User> returning = new List<User>();

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;
                returning = userRepo.Get(user);
            }

            if (returning.Count == 0)
                throw new NoUsersFoundException();

            foreach (User returningUser in returning)
            {
                AccesoService.Instance.GetAccesos(returningUser);
            }

            return returning;
        }

        /// <summary>
        /// Valida si un usuario ya está registrado en el sistema.
        /// </summary>
        /// <param name="user">El objeto usuario a validar.</param>
        /// <returns>True si el usuario ya está registrado, de lo contrario, false.</returns>
        public bool IsRegistered(User user)
        {
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;
                return userRepo.Exists(user);
            }
        }

        /// <summary>
        /// Actualiza los datos de un usuario en la base de datos.
        /// </summary>
        /// <param name="user">El objeto usuario a actualizar.</param>
        /// <exception cref="UserDoesNotExistException">Si el usuario no existe en la base de datos.</exception>
        public void UpdateUser(User user)
        {
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;

                if (!userRepo.Exists(user))
                    throw new UserDoesNotExistException();

                userRepo.Update(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Obtiene una lista de permisos a partir de una lista de accesos.
        /// </summary>
        /// <param name="accesos">Lista de accesos del usuario.</param>
        /// <returns>Lista de permisos asociados a los accesos del usuario.</returns>
        public List<Permiso> GetPermisos(List<Acceso> accesos)
        {
            List<Permiso> permisos = new List<Permiso>();
            GetAllPermisos(accesos, permisos);
            return permisos;
        }

        /// <summary>
        /// Obtiene de forma recursiva todos los permisos a partir de una lista de accesos.
        /// </summary>
        /// <param name="accesos">Lista de accesos inicial.</param>
        /// <param name="permisosReturn">Lista de permisos que se irá llenando recursivamente.</param>
        private void GetAllPermisos(List<Acceso> accesos, List<Permiso> permisosReturn)
        {
            foreach (var acceso in accesos)
            {
                // Si tiene hijos, es un rol con accesos
                if (acceso.HasChildren)
                {
                    GetAllPermisos((acceso as Rol).Accesos, permisosReturn);
                    continue;
                }

                // Si no tiene hijos, es un permiso y se verifica si ya fue agregado
                if (permisosReturn.Any(o => o.Id == acceso.Id))
                    continue;

                permisosReturn.Add(acceso as Permiso);
            }
        }

        /// <summary>
        /// Obtiene una lista de roles a partir de una lista de accesos.
        /// </summary>
        /// <param name="accesos">Lista de accesos del usuario.</param>
        /// <returns>Lista de roles asociados a los accesos del usuario.</returns>
        public List<Rol> GetRoles(List<Acceso> accesos)
        {
            List<Rol> roles = new List<Rol>();
            GetAllRoles(accesos, roles);
            return roles;
        }

        /// <summary>
        /// Obtiene de forma recursiva todos los roles a partir de una lista de accesos.
        /// </summary>
        /// <param name="accesos">Lista de accesos inicial.</param>
        /// <param name="rolesReturn">Lista de roles que se irá llenando recursivamente.</param>
        private void GetAllRoles(List<Acceso> accesos, List<Rol> rolesReturn)
        {
            foreach (var acceso in accesos)
            {
                // Si no tiene hijos, no es un rol, por lo que se omite
                if (!acceso.HasChildren)
                    continue;

                if (!rolesReturn.Any(o => o.Id == acceso.Id))
                    rolesReturn.Add(acceso as Rol);

                GetAllRoles((acceso as Rol).Accesos, rolesReturn);
            }
        }

        /// <summary>
        /// Valida si un usuario cumple con los requisitos de validación de datos.
        /// </summary>
        /// <param name="usr">El objeto usuario a validar.</param>
        /// <param name="results">Lista de resultados de validación.</param>
        /// <returns>True si el usuario es válido, de lo contrario, false.</returns>
        private bool isValid(User usr, List<ValidationResult> results)
        {
            var valContext = new ValidationContext(usr, serviceProvider: null, items: null);
            return Validator.TryValidateObject(usr, valContext, results, true);
        }
    }
}
