using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Exceptions
{
    public class Controller_ObjectHandlingException : Exception
    {
        public Controller_ObjectHandlingException(string message) : base(message) { }
    }
}
