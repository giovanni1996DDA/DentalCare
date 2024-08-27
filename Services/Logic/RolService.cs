using Services.Dao.Factory;
using Services.Dao.Implementations.SQLServer.UnitOfWork;
using Services.Dao.Interfaces;
using Services.Dao.Interfaces.UnitOfWork;
using Services.Domain;
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

        public void CreateRelation(IUnitOfWorkAdapter context, User user, Rol role)
        {
            UserRolRelation relation = new UserRolRelation() { IdUser = user.IdUser,
                                                               IdRol = role.Id};

            IUserRolDao repo = context.Repositories.UserRolRepository;

            if (repo.Exists(relation)) return;

            repo.Create(relation);
            
        }
    }
}
