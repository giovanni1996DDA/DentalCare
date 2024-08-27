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
        public static SqlParameter[] BuildParams(Object obj)
        {
            List<PropertyInfo> Props = obj.GetType().GetProperties().ToList();

            return Props
                   .Where(prop => prop.GetValue(obj) != null)
                   .Select(prop =>
                   {
                       return new SqlParameter($"@{prop.Name}", $"{prop.GetValue(obj)}");
                   })
                   .ToArray();
        }

        public static string BuildWhere(Object obj)
        {
            List<PropertyInfo> Props = obj.GetType().GetProperties().ToList();

            return "WHERE " + String.Join(", ", Props
                                                .Where(prop => prop.GetValue(obj) != null)
                                                .Select(prop => $"{prop.Name} = @{prop.Name}")
                                                .ToList()
                                                );
        }
    }
}
