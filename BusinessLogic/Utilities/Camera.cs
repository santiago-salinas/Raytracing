using BusinessLogic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Camera
    {
        private Vector _lowerLeftCorner;
        private Vector _horizontal;
        private Vector _vertical;
        private Vector _origin;

        private int _resolutionX;
        private int _resolutionY;

        private int _samplesPerPixel;

        public Vector LowerLeftCorner
        {
            get { return _lowerLeftCorner; }
            set { _lowerLeftCorner = value; }
        }

        public Vector Horizontal
        {
            get { return _horizontal; }
            set { _horizontal = value; }
        }

        public Vector Vertical
        {
            get { return _vertical; }
            set { _vertical = value; }
        }

        public Vector Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public int ResolutionX
        {
            get { return _resolutionX; }
            set { _resolutionX = value; }
        }

        public int ResolutionY
        {
            get { return _resolutionY; }
            set { _resolutionY = value; }
        }

        public int SamplesPerPixel
        {
            get { return _samplesPerPixel; }
            set { _samplesPerPixel = value; }
        }

        public Ray GetRay(double u, double v)
        {
            Vector canvasHorizontal = new Vector(4, 0, 0);
            Vector canvasVertical = new Vector(0, 2, 0);

            Vector horizontalPosition = canvasHorizontal.Multiply(u);
            Vector verticalPosition = canvasVertical.Multiply(v);

            Vector pointPosition = LowerLeftCorner.Add(horizontalPosition.Add(verticalPosition));

            Ray ray = new Ray(Origin, pointPosition);
            return ray;
        }
    }
}