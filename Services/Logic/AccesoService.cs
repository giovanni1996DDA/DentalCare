using Services.Dao.Factory;
using Services.Dao.Interfaces;
using Services.Dao.Interfaces.UnitOfWork;
using Services.Domain;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    public class AccesoService
    {
        private static AccesoService instance = new AccesoService();
        public static AccesoService Instance { get { return instance; } }
        private AccesoService()
        {
        }
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
        private List<Rol> Get(Rol rol)
        {
            List<Rol> returning = new List<Rol>();

            using(var context = FactoryDao.UnitOfWork.Create())
            {
                IRolDao rolRepo = context.Repositories.RolRepository;

                returning = rolRepo.Get(rol);
            }

            if (returning.Count == 0) throw new NoRolesFoundForUserException();

            foreach(Rol returningrole in returning)
            {
                FillRol(returningrole);
            }

            return returning;
        }
        private List<Permiso> Get(Permiso permiso)
        {
            List<Permiso> returning = new List<Permiso>();

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IPermisoDao rolRepo = context.Repositories.PermisoRepository;

                returning = rolRepo.Get(permiso);
            }

            if (returning.Count == 0) throw new NoPermissionFoundException();

            return returning;
        }
        /// <summary>
        /// Crea o actualiza el acceso. El metodo se encarga de discernir si corresponde a un permiso o a un rol.
        /// </summary>
        /// <param name="acceso"></param>
        /// <exception cref="ArgumentException"></exception>
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
        /// Crea o actualiza un rol dependiendo de su existencia en la bbdd
        /// </summary>
        /// <param name="rol"></param>
        private void CreateOrUpdate(Rol rol)
        {
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IRolDao repo = context.Repositories.RolRepository;

                if (repo.Exists(rol, (prop => prop.Name == "Id") ))
                {
                    repo.Update(rol);

                    IRolRolDao rrRepo = context.Repositories.RolRolRepository;
                    rrRepo.Delete(new RolRolRelation { FatherId = rol.Id }, (prop => prop.Name == "FatherId"));

                    IRolPermisoDao rpRepo = context.Repositories.RolPermisoRepository;
                    rpRepo.Delete(new RolPermisoRelation { IdRol = rol.Id }, (prop => prop.Name == "IdRol"));

                }
                else
                {
                    //rol.Id = Guid.NewGuid();

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
        /// Crea o actualiza un rol dependiendo de su existencia en la bbdd
        /// </summary>
        /// <param name="permiso"></param>
        private void CreateOrUpdate(Permiso permiso)
        {
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IPermisoDao repo = context.Repositories.PermisoRepository;

                if (repo.Exists(permiso))
                {
                    //Logica para update
                    return;
                }
                permiso.Id = Guid.NewGuid();

                repo.Create(permiso);

                context.SaveChanges();
            }
        }
        /// <summary>
        /// Crea o actualiza una relacion entre el user y el acceso. El método se encarga de discernir si el acceso es un rol o un permiso.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="acceso"></param>
        /// <exception cref="ArgumentException"> si el acceso no esta previsto</exception>
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
        /// Crea o actualiza una relacion entre un rol y un acceso. El método se encarga de discernir si el acceso es un rol o un permiso.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="rol"></param>
        /// <param name="acceso"></param>
        /// <exception cref="ArgumentException"></exception>
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
        /// Crea una relacion entre un user y un rol
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="role"></param>
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
        /// Crea una relacion entre un user y un permiso
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="role"></param>
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
        /// Crea una relacion entre un rol y otro rol
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="role"></param>
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
        /// Crea una relacion entre un rol y un permiso
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="role"></param>
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
        /// Obtiene todos los accesos del usuario desde la bbdd
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <exception cref="NoRolesFoundForUserException"></exception>
        public void GetAccesos(User user)
        {
            List<UserRolRelation> urRelation = null;

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IUserRolDao userRolRepo = context.Repositories.UserRolRepository;

                urRelation = userRolRepo.Get(new UserRolRelation { IdUser = user.Id }, prop => prop.Name == "IdUser");
            }

            foreach (UserRolRelation relation in urRelation)
            {
                //Busco la relacion user - rol
                using (var context = FactoryDao.UnitOfWork.Create())
                {

                    Rol protoRol = new Rol { Id = relation.IdRol };

                    IRolDao rolRepo = context.Repositories.RolRepository;
                    //Agrego el rol de cada relación
                    user.Accesos.Add(rolRepo.Get(protoRol, prop => prop.Name == "Id").FirstOrDefault());
                }
            }

            //A esta altura, user solo tiene roles cargados, asi que los lleno
            foreach (Rol rol in user.Accesos)
            {
                FillRol(rol);
            }

            List<UserPermisoRelation> upRelation = null;

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                upRelation = context.Repositories.UserPermisoRepository.Get(new UserPermisoRelation { IdUser = user.Id }, prop => prop.Name == "IdUser");
            }

            //Si no tiene permisos asociados, no sigo operando
            if (upRelation.Count == 0) return;

            //Busco la relacion user - permiso
            foreach (UserPermisoRelation relation in upRelation)
            {
                Permiso protoPermiso = new Permiso { Id = relation.IdPermiso };

                using (var context = FactoryDao.UnitOfWork.Create())
                {
                    protoPermiso = context.Repositories.PermisoRepository.Get(protoPermiso, prop => prop.Name == "Id").FirstOrDefault();
                }

                if (protoPermiso == null) throw new DatabaseInconsistencyException();

                //Agrego el permiso de cada relacion
                user.Accesos.Add(protoPermiso);
            }

            //Si no hay roles creados, se informa.
            if (user.Accesos.Count == 0) throw new NoRolesFoundForUserException();
        }

        private void FillRol(Rol rol)
        {
            List<RolRolRelation> rrRelation = null;
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                rrRelation = context.Repositories.RolRolRepository.Get(new RolRolRelation() { FatherId = rol.Id }, prop => prop.Name == "FatherId");
            }

            //Levanto todos los roles que tenga el rol
            foreach (RolRolRelation relation in rrRelation)
            {
                Rol fetchedRol = null;
                using (var context = FactoryDao.UnitOfWork.Create())
                {
                    Rol protoRol = new Rol() { Id = relation.ChildId };

                    fetchedRol = context.Repositories.RolRepository.Get(protoRol, prop => prop.Name == "Id").FirstOrDefault();
                }

                if(fetchedRol == null) throw new DatabaseInconsistencyException();

                //Agregar nivel de hidratacion para que el programa no explote
                FillRol(fetchedRol);

                rol.Accesos.Add(fetchedRol);
            }

            List<RolPermisoRelation> rpRelation = null;

            using(var context = FactoryDao.UnitOfWork.Create())
            {
                rpRelation = context.Repositories.RolPermisoRepository.Get(new RolPermisoRelation() { IdRol = rol.Id }, prop => prop.Name == "IdRol");
            }

            //Si no hay permisos asociados entonces no hago nada
            if (rpRelation.Count == 0) return;

            foreach (RolPermisoRelation relation in rpRelation)
            {
                using (var context = FactoryDao.UnitOfWork.Create())
                {
                    Permiso protoPermiso = new Permiso { Id = relation.IdPermiso };

                    protoPermiso = context.Repositories.PermisoRepository.Get(protoPermiso, prop => prop.Name == "Id").FirstOrDefault();

                    if (protoPermiso == null) throw new DatabaseInconsistencyException();

                    rol.Accesos.Add(protoPermiso);
                }
            }
        }
    }
}
