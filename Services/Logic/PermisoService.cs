using Services.Dao.Interfaces.UnitOfWork;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    public class PermisoService
    {
        private static PermisoService instance = new PermisoService();
        public static PermisoService Instance { get { return instance; } }
        private PermisoService()
        {
        }
        public void CreateRelation(IUnitOfWorkAdapter context, User user, Permiso role)
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
