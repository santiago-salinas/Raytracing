using ApplicationLayer.Objects;
using ApplicationLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public interface ISphere
    {
        double Radius { get; set; }
        string Name { get; set; }
        IUser Owner { get; set; }
        IHitRecord IsHitByRay(IRay ray, double tMin, double tMax, IVector position);
    }

}
