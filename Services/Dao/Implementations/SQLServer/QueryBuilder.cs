using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    public static class QueryBuilder
    {
        public static SqlParameter[] BuildParams(List<PropertyInfo> Props, Object obj)
        {
            return Props
                   .Select(prop =>
                   {
                       return new SqlParameter($"@{prop.Name}", $"{prop.GetValue(obj)}");
                   })
                   .ToArray();
        }

        public static string BuildWhere(List<PropertyInfo> Props)
        {
            return "WHERE " + String.Join(", ", Props
                                                .Select(prop => $"{prop.Name} = @{prop.Name}")
                                                .ToList()
                                                );
        }
    }
}
