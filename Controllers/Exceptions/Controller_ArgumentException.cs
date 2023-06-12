using System;

namespace Controllers.Exceptions
{
    public class Controller_ArgumentException : Exception
    {
        public Controller_ArgumentException(string message) : base(message) { }
    }
}
