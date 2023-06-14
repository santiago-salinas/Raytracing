using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Utilities
{
    public interface IColor
    {
        

        double Red { get; set; }
        double Green { get; set; }
        double Blue { get; set; }

        IColor MultiplyBy(double value);
        IColor Add(IColor other);
    }
}
