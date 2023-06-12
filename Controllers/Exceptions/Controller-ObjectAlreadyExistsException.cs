using System;


namespace Controllers.Exceptions
{
    public class Controller_ObjectAlreadyExistsException : Exception
    {
        public Controller_ObjectAlreadyExistsException(string message) : base(message) { }
    }
}
