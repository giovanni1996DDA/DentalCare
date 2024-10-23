using Services.Dao.Factory;
using Services.Dao.Interfaces;
using Services.Dao.Interfaces.UnitOfWork;
using Services.Domain;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Services.Logic
{
    /// <summary>
    /// Proporciona servicios relacionados con la gestión de accesos, roles y permisos.
    /// </summary>
    public class AccesoService
    {
        private static AccesoService instance = new AccesoService();

        /// <summary>
        /// Instancia única del servicio de acceso (patrón Singleton).
        /// </summary>
        public static AccesoService Instance { get { return instance; } }

        /// <summary>
        /// Constructor privado para implementar el patrón Singleton.
        /// </summary>
        private AccesoService()
        {
        }

        /// <summary>
        /// Obtiene una lista de accesos en función del tipo de acceso (Rol o Permiso).
        /// </summary>
        /// <param name="acceso">Objeto de tipo Acceso.</param>
        /// <returns>Una lista de objetos de tipo Acceso.</returns>
        /// <exception cref="ArgumentException">Si el tipo de acceso no es soportado.</exception>
        public List<Acceso> Get(Acceso acceso)
        {
            List<Acceso> returning = new List<Acceso>();
            switch (acceso)
            {
                case Rol rol:
                    returning = Get(rol).Select(r => (Acceso)r).ToList();
                    break;

                case Permiso permiso:
                    returning = Get(permiso).Select(r => (Acceso)r).ToList();
                    break;

                default:
                    throw new ArgumentException("Tipo de acceso no soportado");
            }
            return returning;
        }

        /// <summary>
        /// Obtiene una lista de roles asociados.
        /// </summary>
        /// <param name="rol">Objeto de tipo Rol.</param>
        /// <returns>Una lista de roles.</returns>
        /// <exception cref="NoRolesFoundForUserException">Si no se encuentran roles para el usuario.</exception>
        private List<Rol> Get(Rol rol)
        {
            List<Rol> returning = new List<Rol>();

            int hidratationLevel = int.Parse(ConfigurationManager.AppSettings["AccessesHidrationLvl"]);

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IRolDao rolRepo = context.Repositories.RolRepository;

                returning = rolRepo.Get(rol);
            }

            if (returning.Count == 0) throw new NoRolesFoundForUserException();

            foreach (Rol returningrole in returning)
            {
                FillRol(returningrole, hidratationLevel);
            }

            return returning;
        }

        /// <summary>
        /// Obtiene una lista de permisos asociados.
        /// </summary>
        /// <param name="permiso">Objeto de tipo Permiso.</param>
        /// <returns>Una lista de permisos.</returns>
        /// <exception cref="NoPermissionsFoundException">Si no se encuentran permisos asociados.</exception>
        private List<Permiso> Get(Permiso permiso)
        {
            List<Permiso> returning = new List<Permiso>();

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IPermisoDao rolRepo = context.Repositories.PermisoRepository;

                returning = rolRepo.Get(permiso);
            }

            if (returning.Count == 0) throw new NoPermissionsFoundException();

            return returning;
        }

        private List<Acceso> Get()
        {
            List<Acceso> returning = new List<Acceso>();

            try
            {
                returning.AddRange(Get(new Rol()));
            }
            catch (NoRolesFoundForUserException)
            {
                try
                {
                    returning.AddRange(Get(new Permiso()));
                }
                catch (NoPermissionsFoundException)
                {
                    throw new NoAccesosFoundException();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.", "Error inesperado.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return returning;
        }

        public Acceso GetOne(Acceso acc)
        {
            try
            {
                if (acc is Rol rol)
                    return GetOne(rol);

                if (acc is Permiso permiso)
                    return GetOne(permiso);

                return null;
            }
            catch (NoRolesFoundException)
            {
                throw;
            }
            catch (NoPermissionsFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.", "Error inesperado.", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public Rol GetOne(Rol rol)
        {
            Rol returning = null;

            int hidratationLevel = int.Parse(ConfigurationManager.AppSettings["AccessesHidrationLvl"]);

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IRolDao rolRepo = context.Repositories.RolRepository;

                returning =  rolRepo.GetOne(rol);
            }

            if (returning == null) throw new NoRolesFoundException();

            FillRol(returning, hidratationLevel);

            return returning;
        }

        public Permiso GetOne(Permiso permiso)
        {
            Permiso returning = null;

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IPermisoDao rolRepo = context.Repositories.PermisoRepository;

                returning = rolRepo.GetOne(permiso);
            }

            if (returning == null) throw new NoPermissionsFoundException();

            return returning;
        }

        /// <summary>
        /// Crea o actualiza un acceso (Rol o Permiso) en la base de datos.
        /// </summary>
        /// <param name="acceso">Objeto de tipo Acceso.</param>
        /// <exception cref="ArgumentException">Si el tipo de acceso no es soportado.</exception>
        public void CreateOrUpdate(Acceso acceso)
        {
            switch (acceso)
            {
                case Rol rol:
                    CreateOrUpdate(rol);
                    break;

                case Permiso permiso:
                    CreateOrUpdate(permiso);
                    break;

                default:
                    throw new ArgumentException("Tipo de acceso no soportado");
            }
        }

        /// <summary>
        /// Crea o actualiza un rol en la base de datos dependiendo de su existencia.
        /// </summary>
        /// <param name="rol">Objeto de tipo Rol.</param>
        /// <exception cref="EmptyRoleException">Si el rol no tiene accesos.</exception>
        private void CreateOrUpdate(Rol rol)
        {
            if (rol.Accesos.Count == 0) throw new EmptyRoleException();

            bool roleExists = false;

            List<ValidationResult> results = new List<ValidationResult>();

            if (!isValid(rol, results))
                throw new InvalidUserException(results.FirstOrDefault()?.ErrorMessage);

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IRolDao repo = context.Repositories.RolRepository;

                roleExists = repo.Exists(rol);

                if (roleExists)
                {
                    rol = repo.GetOne(rol);
                }
            }

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IRolDao repo = context.Repositories.RolRepository;

                if (roleExists)
                {
                    repo.Update(rol);

                    IRolRolDao rrRepo = context.Repositories.RolRolRepository;
                    rrRepo.Delete(new RolRolRelation { FatherId = rol.Id });

                    IRolPermisoDao rpRepo = context.Repositories.RolPermisoRepository;
                    rpRepo.Delete(new RolPermisoRelation { IdRol = rol.Id });

                }
                else
                {
                    repo.Create(rol);
                }

                foreach (Acceso acceso in rol.Accesos)
                {
                    CreateRelation(context, rol, acceso);
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Crea o actualiza un permiso en la base de datos dependiendo de su existencia.
        /// </summary>
        /// <param name="permiso">Objeto de tipo Permiso.</param>
        private void CreateOrUpdate(Permiso permiso)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (!isValid(permiso, results))
                throw new InvalidUserException(results.FirstOrDefault()?.ErrorMessage);

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IPermisoDao repo = context.Repositories.PermisoRepository;

                if (repo.Exists(permiso))
                {
                    repo.Update(permiso);
                }
                else
                {
                    permiso.Id = Guid.NewGuid();
                    repo.Create(permiso);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Crea una relación entre un usuario y un acceso (Rol o Permiso).
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo.</param>
        /// <param name="user">Objeto de tipo Usuario.</param>
        /// <param name="acceso">Objeto de tipo Acceso.</param>
        /// <exception cref="ArgumentException">Si el tipo de acceso no es soportado.</exception>
        public void CreateRelation(IUnitOfWorkAdapter context, User user, Acceso acceso)
        {
            switch (acceso)
            {
                case Rol rol:
                    CreateRelation(context, user, rol);
                    break;

                case Permiso permiso:
                    CreateRelation(context, user, permiso);
                    break;

                default:
                    throw new ArgumentException("Tipo de acceso no soportado");
            }
        }

        /// <summary>
        /// Crea una relación entre un rol y un acceso (Rol o Permiso).
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo.</param>
        /// <param name="rol">Objeto de tipo Rol.</param>
        /// <param name="acceso">Objeto de tipo Acceso.</param>
        /// <exception cref="ArgumentException">Si el tipo de acceso no es soportado.</exception>
        public void CreateRelation(IUnitOfWorkAdapter context, Rol rol, Acceso acceso)
        {
            switch (acceso)
            {
                case Rol childRol:
                    CreateRelation(context, rol, childRol);
                    break;

                case Permiso permiso:
                    CreateRelation(context, rol, permiso);
                    break;

                default:
                    throw new ArgumentException("Tipo de acceso no soportado");
            }
        }

        /// <summary>
        /// Crea una relación entre un usuario y un rol.
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo.</param>
        /// <param name="user">Objeto de tipo Usuario.</param>
        /// <param name="role">Objeto de tipo Rol.</param>
        private void CreateRelation(IUnitOfWorkAdapter context, User user, Rol role)
        {
            UserRolRelation relation = new UserRolRelation()
            {
                IdUser = user.Id,
                IdRol = role.Id,
            };

            IUserRolDao repo = context.Repositories.UserRolRepository;

            if (repo.Exists(relation)) return;

            repo.Create(relation);
        }

        /// <summary>
        /// Crea una relación entre un usuario y un permiso.
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo.</param>
        /// <param name="user">Objeto de tipo Usuario.</param>
        /// <param name="permiso">Objeto de tipo Permiso.</param>
        private void CreateRelation(IUnitOfWorkAdapter context, User user, Permiso permiso)
        {
            UserPermisoRelation relation = new UserPermisoRelation()
            {
                IdUser = user.Id,
                IdPermiso = permiso.Id
            };

            IUserPermisoDao repo = context.Repositories.UserPermisoRepository;

            if (repo.Exists(relation)) return;

            repo.Create(relation);
        }

        /// <summary>
        /// Crea una relación entre un rol padre y un rol hijo.
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo.</param>
        /// <param name="rolPadre">Objeto de tipo Rol (padre).</param>
        /// <param name="rolHijo">Objeto de tipo Rol (hijo).</param>
        private void CreateRelation(IUnitOfWorkAdapter context, Rol rolPadre, Rol rolHijo)
        {
            RolRolRelation relation = new RolRolRelation()
            {
                FatherId = rolPadre.Id,
                ChildId = rolHijo.Id,
            };

            IRolRolDao repo = context.Repositories.RolRolRepository;

            if (repo.Exists(relation)) return;

            repo.Create(relation);
        }

        /// <summary>
        /// Crea una relación entre un rol y un permiso.
        /// </summary>
        /// <param name="context">Contexto de la unidad de trabajo.</param>
        /// <param name="rol">Objeto de tipo Rol.</param>
        /// <param name="permiso">Objeto de tipo Permiso.</param>
        private void CreateRelation(IUnitOfWorkAdapter context, Rol rol, Permiso permiso)
        {
            RolPermisoRelation relation = new RolPermisoRelation()
            {
                IdRol = rol.Id,
                IdPermiso = permiso.Id,
            };

            IRolPermisoDao repo = context.Repositories.RolPermisoRepository;

            if (repo.Exists(relation)) return;

            repo.Create(relation);
        }

        /// <summary>
        /// Obtiene todos los accesos de un usuario desde la base de datos.
        /// </summary>
        /// <param name="user">Objeto de tipo Usuario.</param>
        /// <exception cref="NoRolesFoundForUserException">Si no se encuentran roles asociados al usuario.</exception>
        public void GetAccesos(User user)
        {
            List<UserRolRelation> urRelation = null;

            int hidratationLevel = int.Parse(ConfigurationManager.AppSettings["AccessesHidrationLvl"]);

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserRolDao userRolRepo = context.Repositories.UserRolRepository;

                urRelation = userRolRepo.Get(new UserRolRelation { IdUser = user.Id });
            }

            foreach (UserRolRelation relation in urRelation)
            {
                //Busco la relacion user - rol
                using (var context = FactoryDao.UnitOfWork.Create())
                {
                    IRolDao rolRepo = context.Repositories.RolRepository;
                    //Agrego el rol de cada relación
                    user.Accesos.Add(rolRepo.GetOne(new Rol { Id = relation.IdRol }));
                }
            }

            //A esta altura, user solo tiene roles cargados, asi que los lleno
            foreach (Rol rol in user.Accesos)
            {
                FillRol(rol, --hidratationLevel);
            }

            List<UserPermisoRelation> upRelation = null;

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                upRelation = context.Repositories.UserPermisoRepository.Get(new UserPermisoRelation { IdUser = user.Id });
            }

            //Si no tiene permisos asociados, no sigo operando
            if (upRelation.Count == 0) return;

            //Busco la relacion user - permiso
            foreach (UserPermisoRelation relation in upRelation)
            {
                Permiso fetchedPermiso = null;

                using (var context = FactoryDao.UnitOfWork.Create())
                {
                    fetchedPermiso = context.Repositories.PermisoRepository.GetOne(new Permiso { Id = relation.IdPermiso });
                }

                if (fetchedPermiso == null) throw new DatabaseInconsistencyException();

                //Agrego el permiso de cada relacion
                user.Accesos.Add(fetchedPermiso);
            }
        }

        /// <summary>
        /// Rellena un rol con sus accesos hasta el nivel de hidratación especificado.
        /// </summary>
        /// <param name="rol">Objeto de tipo Rol.</param>
        /// <param name="hidratationLevel">Nivel de profundidad de hidratación.</param>
        private void FillRol(Rol rol, int hidratationLevel)
        {
            if (hidratationLevel == 0) return;

            List<RolRolRelation> rrRelation = null;

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                rrRelation = context.Repositories.RolRolRepository.Get(new RolRolRelation() { FatherId = rol.Id });
            }

            // Levanto todos los roles que tenga el rol
            foreach (RolRolRelation relation in rrRelation)
            {
                Rol fetchedRol = null;

                using (var context = FactoryDao.UnitOfWork.Create())
                {
                    Rol protoRol = new Rol() { Id = relation.ChildId };

                    fetchedRol = context.Repositories.RolRepository.GetOne(protoRol);
                }

                if (fetchedRol == null) throw new DatabaseInconsistencyException();

                //Agregar nivel de hidratacion para que el programa no explote
                FillRol(fetchedRol, --hidratationLevel);

                rol.Accesos.Add(fetchedRol);
            }

            List<RolPermisoRelation> rpRelation = null;

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                rpRelation = context.Repositories.RolPermisoRepository.Get(new RolPermisoRelation() { IdRol = rol.Id });
            }

            // Si no hay permisos asociados entonces no hago nada
            if (rpRelation.Count == 0) return;

            foreach (RolPermisoRelation relation in rpRelation)
            {
                using (var context = FactoryDao.UnitOfWork.Create())
                {
                    Permiso protoPermiso = new Permiso { Id = relation.IdPermiso };

                    protoPermiso = context.Repositories.PermisoRepository.GetOne(protoPermiso);

                    if (protoPermiso == null) throw new DatabaseInconsistencyException();

                    rol.Accesos.Add(protoPermiso);
                }
            }
        }

        /// <summary>
        /// Valida si un objeto Acceso cumple con las reglas de validación.
        /// </summary>
        /// <param name="acceso">Objeto de tipo Acceso.</param>
        /// <param name="results">Lista donde se almacenan los resultados de la validación.</param>
        /// <returns>True si el objeto es válido, false si no lo es.</returns>
        private bool isValid(Acceso acceso, List<ValidationResult> results)
        {
            var valContext = new ValidationContext(acceso, serviceProvider: null, items: null);

            return Validator.TryValidateObject(acceso, valContext, results, true);
        }
    }
}
