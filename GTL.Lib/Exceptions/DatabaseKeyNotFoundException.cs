using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GTL.Lib.Exceptions
{
    public class DatabaseKeyNotFoundException : Exception
    {
        public DatabaseKeyNotFoundException()
        {
        }

        public DatabaseKeyNotFoundException(string message) : base(message)
        {
        }

        public DatabaseKeyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DatabaseKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
