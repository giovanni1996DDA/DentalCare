using System;
using System.Runtime.Serialization;

namespace Services.Logic
{
    [Serializable]
    public class RoleAlreadyExistInFatherException : Exception
    {
        public RoleAlreadyExistInFatherException() : base("El rol que se está intentando agregar ya existe como hijo.")
        {
        }

        public RoleAlreadyExistInFatherException(string message) : base(message)
        {
        }

        public RoleAlreadyExistInFatherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoleAlreadyExistInFatherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}