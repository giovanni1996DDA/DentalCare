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
    public class UserService
    {
        #region Singleton
        private static readonly UserService instance = new UserService();
        public static UserService Instance { 
            get
            {
                return instance;
            }
        }
        private UserService() { }
        #endregion
        /// <summary>
        /// Registra un usuario en la base de datos
        /// </summary>
        /// <param name="user"></param>
        public void RegisterUser(User user)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (!isValid(user, results))
                throw new InvalidUserException(results.FirstOrDefault()?.ErrorMessage);

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;

                //Verifico si existe un usuario con ese UserName
                if (userRepo.Exists(user, (prop => prop.Name == "UserName"))) throw new UserAlreadyRegisteredException();

            }

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;

                //Verifico si existe un usuario con ese UserName
                //if (userRepo.Get(user, prop => prop.Name == "UserName").Count > 0) throw new UserAlreadyRegisteredException();

                userRepo.Create(user);

                foreach (Acceso access in user.Accesos)
                {
                    AccesoService.Instance.CreateRelation(context, user, access);
                }
                
                context.SaveChanges();
            }
        }
        public List<User> Get(User user)
        {
            List<User> returning = new List<User>();

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;
                returning = userRepo.Get(user);
            }

            if (returning.Count == 0) throw new NoUsersFoundException();

            foreach (User returningUser in returning)
            {
                AccesoService.Instance.GetAccesos(returningUser);
            }

            return returning;
        }
        /// <summary>
        /// Valida si un usuario se encuentra registrado en el sistema
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsRegistered(User user) 
        {
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;
                return userRepo.Exists(user);
            }
        }
        public void UpdateUser(User user) 
        {
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserDao userRepo = context.Repositories.UserRepository;

                if (!userRepo.Exists(user)) throw new UserDoesNotExistException();

                userRepo.Update(user);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Obtengo todas las patentes de los accesos
        /// </summary>
        /// <param name="accesos"></param>
        /// <returns></returns>
        public List<Permiso> GetPermisos(List<Acceso> accesos)
        {
            List<Permiso> patentes = new List<Permiso>();

            GetAllPermisos(accesos, patentes);

            return patentes;
        }
        /// <summary>
        /// Bucea entre todos los accesos que tiene, validando si es una familia de pantentes o una patente en si
        /// </summary>
        /// <param name="accesos"></param>
        /// <param name="permisosReturn"></param>
        private void GetAllPermisos(List<Acceso> accesos, List<Permiso> permisosReturn)
        {
            foreach (var acceso in accesos)
            {
                //Si tiene hijos es una familia
                if (acceso.HasChildren)
                {
                    GetAllPermisos((acceso as Rol).Accesos, permisosReturn);
                    continue;
                }

                //Si no es una familia, valido si la patente ya fue agregada entonces continuo con el siguiente registro
                if (permisosReturn.Any(o => o.Id == acceso.Id))
                    continue;

                permisosReturn.Add(acceso as Permiso);
            }
        }
        /// <summary>
        /// Obtengo todas las familias de los accesos
        /// </summary>
        /// <param name="accesos"></param>
        /// <returns></returns>
        public List<Rol> GetRoles(List<Acceso> accesos)
        {

            List<Rol> familias = new List<Rol>();

            GetAllRoles(accesos, familias);

            return familias;

        }
        /// <summary>
        /// Bucea entre todas las familias que tiene, validando si es una familia de falimlias o una familia en si
        /// </summary>
        /// <param name="accesos"></param>
        /// <param name="famililaReturn"></param>
        private void GetAllRoles(List<Acceso> accesos, List<Rol> famililaReturn)
        {
            foreach (var acceso in accesos)
            {
                //Si no tiene hijos no me interesa
                if (!acceso.HasChildren)
                    continue;

                if (!famililaReturn.Any(o => o.Id == acceso.Id))
                    famililaReturn.Add(acceso as Rol);

                GetAllRoles((acceso as Rol).Accesos, famililaReturn);
            }
        }
        private bool isValid(User usr, List<ValidationResult> results)
        {
            var valContext = new ValidationContext(usr, serviceProvider: null, items: null);

            return Validator.TryValidateObject(usr, valContext, results, true);
        }
    }
}
