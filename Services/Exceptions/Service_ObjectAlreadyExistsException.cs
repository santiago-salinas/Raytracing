using System;

namespace Services.Exceptions
{
    public class Service_ObjectAlreadyExistsException : Exception
    {
        public Service_ObjectAlreadyExistsException(string message) : base(message) { }
    }
}
