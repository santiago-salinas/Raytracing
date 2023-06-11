using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class Service_ArgumentException : Exception
    {
        public Service_ArgumentException(string message): base(message) { }
    }
}
