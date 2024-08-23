using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Dao.Interfaces.UnitOfWork;
using System.Runtime.Remoting.Contexts;

namespace Services.Dao.Factory
{
    public static class FactoryDao
    {
        /// <summary>
        /// Fabrica de instancias de repositorios. Los repositorios estan definidos de forma de que sea un repositorio transaccional con 
        /// unidad de trabajo.
        /// </summary>
        static FactoryDao()
        {
            int backTypeValue = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            string backTypeName = Enum.GetName(typeof(BackendType), backTypeValue);

            string unitOfWorkString = $"Services.Dao.Implementations.SQLServer.UnitOfWork.UnitOfWork{backTypeName}";

            Type UnitOfWorkType = Type.GetType(unitOfWorkString);

            //creo la instancia del tipo de repo
            var UnitOfWorkInstance = Activator.CreateInstance(UnitOfWorkType) as IUnitOfWork;

            UnitOfWork = UnitOfWorkInstance;

        }
        public static IUnitOfWork UnitOfWork { get; private set; }
    }
    internal enum BackendType
    {
        Memory,
        SQLServer,
        Sqlite,
        Oracle
    }
}
