using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Objects;
using ApplicationLayer.Utilities;


namespace ApplicationLayer
{
    public interface IHitRecord
    {
        bool IsHit { get; set; }

        double TDistanceFromOrigin { get; set; }

        IVector Intersection { get; set; }

        IVector Normal { get; set; }

        IColor Attenuation { get; set; }
    }
}
