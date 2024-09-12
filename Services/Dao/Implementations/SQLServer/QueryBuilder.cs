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
        private static List<PropertyInfo> GetProperties(Type type)
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
        public static SqlParameter[] BuildParams<T>(T obj)
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

            // Si no hay propiedades válidas, devolver un array vacío
            if (!filteredProps.Any())
                return new SqlParameter[0];

            // Construir y devolver los parámetros
            return filteredProps
                   .Select(prop => new SqlParameter($"@{prop.Name}", prop.GetValue(obj)))
                   .ToArray();
        }

        /// <summary>
        /// Construye una cláusula WHERE para una consulta SQL, basada en las propiedades no nulas del objeto proporcionado.
        /// </summary>
        /// <typeparam name="T">El tipo del objeto a analizar.</typeparam>
        /// <param name="obj">El objeto cuyas propiedades se usarán para generar la cláusula WHERE.</param>
        /// <returns>Una cadena que representa la cláusula WHERE basada en las propiedades no nulas del objeto.</returns>
        public static string BuildWhere<T>(T obj)
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

            // Construir la cláusula WHERE
            return "WHERE " + String.Join(" AND ", filteredProps.Select(prop => $"{prop.Name} = @{prop.Name}"));
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
            return String.Join(", ", props.Select(prop => prop.Name));
        }

        /// <summary>
        /// Construye una cadena con los nombres de los parámetros para ser utilizada en una sentencia INSERT en SQL.
        /// </summary>
        /// <typeparam name="T">El tipo del objeto a analizar.</typeparam>
        /// <returns>Una cadena que contiene los nombres de los parámetros separados por comas.</returns>
        public static string BuildParamNames<T>()
        {
            var props = GetProperties(typeof(T)).Where(prop => !Attribute.IsDefined(prop, typeof(NotMappedAttribute)));
            return String.Join(", ", props.Select(prop => $"@{prop.Name}"));
        }
    }
}
