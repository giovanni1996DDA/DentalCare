using Services.Dao.Factory;
using Services.Dao.Interfaces;
using Services.Domain;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    public class ScreenService
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

        public Screen GetOne(Screen scr)
        {
            Screen returning = null;

            using (var context = FactoryDao.UnitOfWork.Create())
            {
                IScreenDao scrRepo = context.Repositories.ScreenRepository;
                returning = scrRepo.GetOne(scr);
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
                returning = scrRepo.Get(scr);
            }

            if (!returning.Any())
                throw new NoScreensFoundException();

            return returning;
        }
    }
}
