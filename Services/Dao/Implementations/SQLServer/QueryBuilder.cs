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
        /*public static SqlParameter[] BuildParams(List<PropertyInfo> Props, Object obj)
        {
            // Verificar el tipo del objeto para asegurarse de que se puede acceder a las propiedades de manera segura
            var objType = obj.GetType();

            return Props
                   .Where(prop => objType.GetProperty(prop.Name) != null) // Asegurarse de que la propiedad existe en el objeto
                   .Select(prop =>
                   {
                       var value = prop.GetValue(obj);
                       return new SqlParameter($"@{prop.Name}", value ?? DBNull.Value);
                   })
                   .ToArray();
        }*/

        //V2
        public static SqlParameter[] BuildParams(List<PropertyInfo> Props, object obj)
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
            return "WHERE " + String.Join(" AND ", Props
                                                .Select(prop => $"{prop.Name} = @{prop.Name}")
                                                .ToList()
                                                );
        }
    }
}
