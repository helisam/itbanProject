using System;

namespace Services.Exceptions
{
    public class ParametroInvalidoException : Exception
    {
        public ParametroInvalidoException() { }
        public ParametroInvalidoException(string message) : base(message) { }
        public ParametroInvalidoException(string message, Exception inner) : base(message, inner) { }
        protected ParametroInvalidoException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}