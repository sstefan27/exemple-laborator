using System;
using System.Runtime.Serialization;

namespace Lucrarea01.Domain
{
    [Serializable]
    internal class InvalidProductRegistrationNumber : Exception
    {
        public InvalidProductRegistrationNumber()
        {
        }

        public InvalidProductRegistrationNumber(string message) : base(message)
        {
        }

        public InvalidProductRegistrationNumber(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProductRegistrationNumber(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}