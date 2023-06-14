using System;

namespace Controllers.Exceptions
{
    public class Controller_ObjectHandlingException : Exception
    {
        public Controller_ObjectHandlingException(string message) : base(message) { }
    }
}
