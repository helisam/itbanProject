using System;

namespace Services.Exceptions
{
    [Serializable]
    public class ServiceBaseException : Exception
    {
        public ServiceBaseException() { }
        public ServiceBaseException(string message) : base(message) { }
        public ServiceBaseException(string message, Exception inner) : base(message, inner) { }
        protected ServiceBaseException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
