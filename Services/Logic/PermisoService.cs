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
        public void CreateRelation(IUnitOfWorkAdapter context, User user, Permiso permiso)
        {
            UserPermisoRelation relation = new UserPermisoRelation()
            {
                user = user,
                permiso = permiso
            };

            IUserPermisoDao repo = context.Repositories.UserPermisoRepository;

            //if (repo.Exists(relation)) return;

            repo.Create(relation);

        }
    }
}
