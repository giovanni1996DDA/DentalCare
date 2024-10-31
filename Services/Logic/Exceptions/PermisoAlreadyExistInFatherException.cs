using System;
using System.Runtime.Serialization;

namespace Services.Logic.Exceptions
{
    [Serializable]
    internal class PermisoAlreadyExistInFatherException : Exception
    {
        public PermisoAlreadyExistInFatherException() : base("El permiso que se está intentando agregar ya existe como hijo.")
        {
        }

        public PermisoAlreadyExistInFatherException(string message) : base(message)
        {
        }

        public PermisoAlreadyExistInFatherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PermisoAlreadyExistInFatherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}