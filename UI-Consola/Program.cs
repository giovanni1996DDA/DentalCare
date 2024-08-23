using Services.Dao.Factory;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = FactoryDao.UnitOfWork.Create();

            context.Repositories.LoggerRepository.WriteLog(new Log() { 
                                                                        Date = DateTime.Now,
                                                                        Message = "Test",
                                                                        TraceLevel = TraceLevel.Info });
        }
    }
}
