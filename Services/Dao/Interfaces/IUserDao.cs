

using Services.Domain;
using System;

namespace Services.Dao.Interfaces
{
    public interface IUserDao : IGenericDao<User>
    {
        User GetById(Guid id);
    }
}
