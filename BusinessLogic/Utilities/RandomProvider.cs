using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RandomProvider : Random
    {
        public override double NextDouble()
        {
            return 0.0;
        }
    }
}
