using System;
using System.Runtime.Serialization;

namespace Lucrarea01.Domain
{
    [Serializable]
    internal class InvalidProductAmount : Exception
    {
        public InvalidProductAmount()
        {
        }

        public InvalidProductAmount(string message) : base(message)
        {
        }

        public InvalidProductAmount(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProductAmount(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}