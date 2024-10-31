using System;
using System.Runtime.Serialization;

namespace Services.Logic.Exceptions
{
    [Serializable]
    public class PermisoWithCredentialsAlreadyExistsException : Exception
    {
        public PermisoWithCredentialsAlreadyExistsException() : base("Ya existe un permiso con ese tipo y ese modulo creado.")
        {
        }

        public PermisoWithCredentialsAlreadyExistsException(string message) : base(message)
        {
        }

        public PermisoWithCredentialsAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PermisoWithCredentialsAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}