using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.Mappers
{
    internal static class UserMapper
    {
        public static User Map(object[] values)
        {
            return new User()
            {
                IdUser   = Guid.Parse($"{values[(int)UserColumns.UserId]}"),
                UserName = (string)values[(int)UserColumns.UserName],
                Password = (string)values[(int)UserColumns.Password],
            };
        }
    }

    internal enum UserColumns
    {
        UserId = 0,
        UserName = 1,
        Password = 2
    }
}
