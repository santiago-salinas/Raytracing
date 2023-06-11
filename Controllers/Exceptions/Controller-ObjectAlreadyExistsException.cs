using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Exceptions
{
    public class Controller_ObjectAlreadyExistsException : Exception
    {
        public Controller_ObjectAlreadyExistsException(string message) : base(message) { }
    }
}
