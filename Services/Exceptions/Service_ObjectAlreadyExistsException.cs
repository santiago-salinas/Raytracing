using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class Service_ObjectAlreadyExistsException : Exception
    {
        public Service_ObjectAlreadyExistsException(string message) : base(message) { }
    }
}
