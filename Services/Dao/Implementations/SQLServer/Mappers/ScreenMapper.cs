using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer.Mappers
{
    internal class ScreenMapper
    {
        public static Screen Map(object[] values)
        {
            return new Screen()
            {
                OptionName = $"{values[(int)ScreenColumns.OptionName]}",
                ScreenName = $"{values[(int)ScreenColumns.ScreenName]}",
                rol = Guid.Parse($"{values[(int)ScreenColumns.Rol]}"),
            };
        }
    }


    internal enum ScreenColumns
    {

        OptionName = 0,

        ScreenName = 1,

        Rol = 2
    }
}
