using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    internal interface ICamera
    {
        Ray GetRay(double u, double v);

        double Theta { get; set; }
        double HeightHalf { get; set; }
        int ResolutionX { get; set; }
        int ResolutionY { get; set; }
        double AspectRatio { get; set; }
        double WidthHalf { get; set; }
        Vector Origin { get; set; }
        Vector VectorW { get; set; }
        Vector VectorU { get; set; }
        Vector VectorV { get; set; }
        Vector LowerLeftCorner { get; set; }
        Vector Horizontal { get; set; }
        Vector Vertical { get; set; }

        int SamplesPerPixel { get; set; }
        int MaxDepth { get; set; }
    }

}
