using System;

namespace Services.Exceptions
{
    public class Service_ObjectHandlingException : Exception
    {
        public Service_ObjectHandlingException(string message) : base(message) { }
    }
}
