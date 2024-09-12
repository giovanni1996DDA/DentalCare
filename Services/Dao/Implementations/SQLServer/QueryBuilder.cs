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
        public static SqlParameter[] BuildParams(List<PropertyInfo> Props, object obj)
        {
            var filteredProps = Props.Where(prop => prop.GetValue(obj) != null).ToList();

            // Si no hay propiedades válidas, devolver un array vacío
            if (!filteredProps.Any())
                return new SqlParameter[0];

            return filteredProps
                   .Select(prop => new SqlParameter($"@{prop.Name}", $"{prop.GetValue(obj)}"))
                   .ToArray();
        }
        public static string BuildWhere(List<PropertyInfo> Props, object obj)
        {
            var filteredProps = Props.Where(prop => prop.GetValue(obj) != null).ToList();

            // Si no hay propiedades válidas, devolver una cadena vacía
            if (!filteredProps.Any())
                return string.Empty;

            // Construir la cláusula WHERE solo si hay propiedades válidas
            return "WHERE " + String.Join(" AND ", filteredProps.Select(prop => $"{prop.Name} = @{prop.Name}"));
        }
        public static string BuildSet(List<PropertyInfo> Props, object obj)
        {
            var filteredProps = Props.Where(prop => prop.GetValue(obj) != null).ToList();

            // Si no hay propiedades válidas, devolver una cadena vacía
            if (!filteredProps.Any())
                return string.Empty;

            return "SET " + String.Join(", ", filteredProps.Select(prop => $"{prop.Name} = @{prop.Name}"));
        }

        public static string BuildColumnNames(List<PropertyInfo> Props)
        {
            return String.Join(", ", Props.Select(prop => prop.Name));
        }

        public static string BuildParamNames(List<PropertyInfo> Props)
        {
            return String.Join(", ", Props.Select(prop => $"@{prop.Name}"));
        }
    }
}
