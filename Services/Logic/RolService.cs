using Services.Dao.Factory;
using Services.Dao.Implementations.SQLServer.UnitOfWork;
using Services.Dao.Interfaces;
using Services.Dao.Interfaces.UnitOfWork;
using Services.Domain;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    public class RolService
    {
        private static RolService instance = new RolService();
        public static RolService Instance { get { return instance; } }
        private RolService() 
        { 
        }
        /// <summary>
        /// Busca en la BBDD los roles que tiene asignado un usuario en específico
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NoRolesFoundForUserException"></exception>
        public List<Rol> GetByUser(User user)
        {
            List<Rol> returning = new List<Rol>();

            using(var context = FactoryDao.UnitOfWork.Create())
            {
                //Levanto de la tabla de relaciones el id de cada rol
                List<UserRolRelation> relations = context.Repositories.UserRolRepository.Get(null, prop => prop.Name == "IdUser");

                //Por cada ID que levante, busco los roles en la bbdd y los agrego a la lista de return
                foreach (UserRolRelation relation in relations)
                {
                    returning.Add( context.Repositories.RolRepository.Get( new Rol() { Id = relation.IdRol }, prop => prop.Name == "Id" ).FirstOrDefault() );
                }
            }

            //Si no hay roles creados, se informa.
            if (returning.Count == 0) throw new NoRolesFoundForUserException(user.UserName);

            return returning;
        }
        public void CreateRelation(IUnitOfWorkAdapter context, User user, Rol role)
        {
            UserRolRelation relation = new UserRolRelation() 
            {   
                IdUser = user.IdUser,
                IdRol = role.Id
            };

            IUserRolDao repo = context.Repositories.UserRolRepository;

            if (repo.Exists(relation)) return;

            repo.Create(relation);
            
        }
    }
}
