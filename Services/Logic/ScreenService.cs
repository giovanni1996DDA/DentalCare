using Services.Dao.Factory;
using Services.Dao.Implementations.SQLServer;
using Services.Dao.Interfaces;
using Services.Domain;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Screen = Services.Domain.Screen;

namespace Services.Logic
{
    public class ScreenService : Logic<Screen>
    {
        private static ScreenService _instance = new ScreenService();

        public static ScreenService Instance { 
            get 
            {
                return _instance;
            }
        }

        private ScreenService()
        {

        }
        private void Update(Screen scr)
        {
            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IScreenDao scrRepo = context.Repositories.ScreenRepository;

                List<FilterProperty> filters = BuildFilters(scr);

                scrRepo.Update(filters);

                context.SaveChanges();
            }
        }
        public void DeleteRelations(Permiso permiso)
        {
            List<Screen> screens = new List<Screen>();

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IScreenDao scrRepo = context.Repositories.ScreenRepository;

                screens.AddRange(scrRepo.Get(BuildFilters(new Screen() { Acceso = permiso.Id })));
            }

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IScreenDao scrRepo = context.Repositories.ScreenRepository;

                screens.ForEach(scr =>
                {
                    scr.Acceso = Guid.Empty;

                    List<FilterProperty> filters = BuildFilters(scr);

                    scrRepo.Update(filters);
                });

                context.SaveChanges();
            }
        }
        public void AgregarPermisoAScreen(Permiso permiso, Screen scr)
        {
            permiso.Screens.Add(scr);
        }
        public void CreateRelation(Permiso permiso, Screen scr)
        {
            scr.Acceso = permiso.Id;

            Update(scr);
        }
        public Screen GetOne(Screen scr)
        {
            Screen returning = null;

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IScreenDao scrRepo = context.Repositories.ScreenRepository;

                List<FilterProperty> filters = BuildFilters(scr);

                returning = scrRepo.GetOne(filters);
            }

            if (returning is null)
                throw new NoScreensFoundException();

            return returning;
        }

        public List<Screen> Get(Screen scr)
        {
            List<Screen> returning = new List<Screen>();

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IScreenDao scrRepo = context.Repositories.ScreenRepository;

                List<FilterProperty> filters = BuildFilters(scr);

                returning = scrRepo.Get(filters);
            }
            return returning;
        }

        public void RemoveScreenFromPermiso(Permiso permiso, Screen scr)
        {
            permiso.Screens.Remove(scr);
        }
    }
}
