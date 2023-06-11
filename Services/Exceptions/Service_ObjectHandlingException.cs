using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class Service_ObjectHandlingException : Exception
    {
        public Service_ObjectHandlingException(string message) : base(message) { }
    }
}
