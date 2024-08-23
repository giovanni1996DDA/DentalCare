using Services.Dao.Implementations.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        IUserDao UserRepository { get; }
        LoggerDao LoggerRepository { get; }
    }
}
