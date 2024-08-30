

using Services.Domain;
using System;
using System.Collections.Generic;

namespace Services.Dao.Interfaces
{
    public interface IUserDao : IGenericDao<User>
    {
        bool Exists(User user);
    }
}
