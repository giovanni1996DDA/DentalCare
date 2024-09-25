using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Services.Dao.Implementations.SQLServer
{
    /// <summary>
    /// Clase estática encargada de construir consultas SQL dinámicas y generar parámetros basados en las propiedades de los objetos.
    /// </summary>
    public static class QueryBuilder
    {
        /// <summary>
        /// Cache de propiedades por tipo para evitar múltiples accesos a través de Reflection.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, List<PropertyInfo>> _propertiesCache = new ConcurrentDictionary<Type, List<PropertyInfo>>();

        /// <summary>
        /// Obtiene las propiedades del tipo especificado utilizando Reflection. Las propiedades se almacenan en caché para mejorar el rendimiento.
        /// </summary>
        /// <param name="type">El tipo del que se deben obtener las propiedades.</param>
        /// <returns>Una lista de propiedades del tipo especificado.</returns>
        public static List<PropertyInfo> GetProperties(Type type)
        {
            if (_propertiesCache.ContainsKey(type))
                return _propertiesCache[type];

            var props = type.GetProperties().Where(prop => prop.CanRead && !Attribute.IsDefined(prop, typeof(NotMappedAttribute))).ToList();
            _propertiesCache.TryAdd(type, props);
            return props;
        }

        /// <summary>
        /// Construye un array de parámetros SQL basado en las propiedades no nulas del objeto proporcionado.
        /// </summary>
        /// <typeparam name="T">El tipo del objeto a analizar.</typeparam>
        /// <param name="obj">El objeto cuyas propiedades se convertirán en parámetros SQL.</param>
        /// <returns>Un array de SqlParameter basado en las propiedades no nulas del objeto.</returns>
        public static SqlParameter[] BuildParams(List<FilterProperty> filters)
        {
            var parameters = new List<SqlParameter>();

            foreach (var filter in filters)
            {
                // Para IN no hace falta agregar un parametro
                if (filter.Operation == FilterOperation.In)
                    continue; 

                parameters.Add(new SqlParameter($"@{filter.PropertyName}", filter.Value));
            }

            return parameters.ToArray();
        }

        public static SqlParameter[] BuildParams<T>(T obj)
        {
            var props = GetProperties(typeof(T)).Where(prop => !Attribute.IsDefined(prop, typeof(NotMappedAttribute)));
            var parameters = new List<SqlParameter>();

            foreach (var prop in props)
            {
                var value = prop.GetValue(obj);

                if (IsComplexType(prop.PropertyType) && value != null)
                {
                    // Extraer el Id de la subclase
                    var subValue = GetProperties(prop.PropertyType)
                                   .Where(p => p.Name == "Id")
                                   .Select(p => p.GetValue(value))
                                   .FirstOrDefault();

                    parameters.Add(new SqlParameter($"@{prop.Name}Id", subValue ?? DBNull.Value)); // Parámetro es SubclaseId
                }
                else if (value != null)
                {
                    parameters.Add(new SqlParameter($"@{prop.Name}", value));
                }
            }

            return parameters.ToArray();
        }

        /// <summary>
        /// Construye una cláusula WHERE para una consulta SQL, basada en las propiedades no nulas del objeto proporcionado.
        /// </summary>
        /// <typeparam name="T">El tipo del objeto a analizar.</typeparam>
        /// <param name="obj">El objeto cuyas propiedades se usarán para generar la cláusula WHERE.</param>
        /// <returns>Una cadena que representa la cláusula WHERE basada en las propiedades no nulas del objeto.</returns>
        public static string BuildWhere(List<FilterProperty> filters)
        {
            if (filters == null || !filters.Any())
                return string.Empty;

            var conditions = new List<string>();

            foreach (var filter in filters)
            {
                string condition = string.Empty;

                switch (filter.Operation)
                {
                    case FilterOperation.Equals:
                        condition = $"{filter.PropertyName} = @{filter.PropertyName}";
                        break;

                    case FilterOperation.NotEquals:
                        condition = $"{filter.PropertyName} != @{filter.PropertyName}";
                        break;

                    case FilterOperation.GreaterThan:
                        condition = $"{filter.PropertyName} > @{filter.PropertyName}";
                        break;

                    case FilterOperation.LessThan:
                        condition = $"{filter.PropertyName} < @{filter.PropertyName}";
                        break;

                    case FilterOperation.In:
                        condition = $"{filter.PropertyName} IN ({BuildInClause(filter.Value)})";
                        break;

                    case FilterOperation.Like:
                        condition = $"{filter.PropertyName} LIKE @{filter.PropertyName}";
                        break;

                    default:
                        throw new ArgumentException("Operación no soportada");
                }

                conditions.Add(condition);
            }

            return "WHERE " + string.Join(" AND ", conditions);
        }

        // Método auxiliar para manejar el operador IN
        private static string BuildInClause(object value)
        {
            if (value is IEnumerable<object> values)
            {
                return string.Join(", ", values.Select(v => $"'{v}'"));
            }
            throw new ArgumentException("El valor para IN debe ser una colección");
        }

        /// <summary>
        /// Construye una cláusula SET para una sentencia UPDATE en SQL, basada en las propiedades no nulas del objeto proporcionado.
        /// </summary>
        /// <typeparam name="T">El tipo del objeto a analizar.</typeparam>
        /// <param name="obj">El objeto cuyas propiedades se usarán para generar la cláusula SET.</param>
        /// <returns>Una cadena que representa la cláusula SET para una sentencia UPDATE en SQL.</returns>
        public static string BuildSet<T>(T obj)
        {
            // Obtener propiedades que no tengan [NotMapped] y puedan leerse.
            var props = GetProperties(typeof(T))
                        .Where(prop => !Attribute.IsDefined(prop, typeof(NotMappedAttribute)))
                        .ToList();

            // Filtrar propiedades que no sean nulas y, en el caso de GUIDs, que no sean GUID.Empty
            var filteredProps = props.Where(prop =>
            {
                var value = prop.GetValue(obj);

                // Excluir propiedades nulas
                if (value == null)
                    return false;

                // Si la propiedad es de tipo GUID, excluir GUID.Empty
                if (prop.PropertyType == typeof(Guid) && (Guid)value == Guid.Empty)
                    return false;

                return true;
            }).ToList();

            // Si no hay propiedades válidas, retornar string.Empty
            if (!filteredProps.Any())
                return string.Empty;

            // Construir la cláusula SET
            return "SET " + String.Join(", ", filteredProps.Select(prop => $"{prop.Name} = @{prop.Name}"));
        }

        /// <summary>
        /// Construye una cadena con los nombres de las columnas para ser utilizada en una consulta SELECT o INSERT en SQL.
        /// </summary>
        /// <typeparam name="T">El tipo del objeto a analizar.</typeparam>
        /// <returns>Una cadena que contiene los nombres de las columnas separadas por comas.</returns>
        public static string BuildColumnNames<T>()
        {
            var props = GetProperties(typeof(T)).Where(prop => !Attribute.IsDefined(prop, typeof(NotMappedAttribute)));

            return String.Join(", ", props.SelectMany(prop =>
            {
                if (IsComplexType(prop.PropertyType)) // Si es una clase compleja (subclase)
                {
                    // Extraer el nombre de la propiedad clave (ejemplo: Id) de la subclase
                    return GetProperties(prop.PropertyType)
                           .Where(p => p.Name == "Id")  // Por convención, usamos 'Id', pero esto puede ajustarse
                           .Select(p => $"{prop.Name}Id"); // Generamos el nombre como SubclaseId
                }
                return new[] { prop.Name }; // Si no es una clase, usamos su nombre normalmente
            }));
        }

        /// <summary>
        /// Construye una cadena con los nombres de los parámetros para ser utilizada en una sentencia INSERT en SQL.
        /// </summary>
        /// <typeparam name="T">El tipo del objeto a analizar.</typeparam>
        /// <returns>Una cadena que contiene los nombres de los parámetros separados por comas.</returns>
        public static string BuildParamNames<T>()
        {
            var props = GetProperties(typeof(T)).Where(prop => !Attribute.IsDefined(prop, typeof(NotMappedAttribute)));

            return String.Join(", ", props.SelectMany(prop =>
            {
                if (IsComplexType(prop.PropertyType))
                {
                    // Extraer el nombre de la propiedad clave de la subclase (Id por convención)
                    return GetProperties(prop.PropertyType)
                           .Where(p => p.Name == "Id")
                           .Select(p => $"@{prop.Name}Id");  // Parámetro será @SubclaseId
                }
                return new[] { $"@{prop.Name}" };
            }));
        }
        private static bool IsComplexType(Type type)
        {
            // Determinar si el tipo es una clase compleja (excluyendo tipos básicos como string, Guid, int, etc.)
            return type.IsClass && type != typeof(string) && type != typeof(Guid);
        }
    }
}
