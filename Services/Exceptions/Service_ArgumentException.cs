using System;

namespace Services.Exceptions
{
    public class Service_ArgumentException : Exception
    {
        public Service_ArgumentException(string message) : base(message) { }
    }
}
