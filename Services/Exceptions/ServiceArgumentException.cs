using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class ServiceArgumentException : Exception
    {
        public ServiceArgumentException(string message): base(message) { }
    }
}
