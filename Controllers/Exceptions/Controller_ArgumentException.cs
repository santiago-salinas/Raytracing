using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Exceptions
{
    public class Controller_ArgumentException: Exception
    {
        public Controller_ArgumentException(string message) : base(message){ }
    }
}
