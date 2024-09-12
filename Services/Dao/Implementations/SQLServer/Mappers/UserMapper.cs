using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer.Mappers
{
    internal static class UserMapper
    {
        public static User Map(object[] values)
        {
            return new User()
            {
                Id   = Guid.Parse($"{values[(int)UserColumns.IdUser]}"),
                UserName = (string)values[(int)UserColumns.UserName],
                Password = (string)values[(int)UserColumns.Password],
            };
        }
    }

    internal enum UserColumns
    {
        IdUser = 0,
        UserName = 1,
        Password = 2
    }
}
