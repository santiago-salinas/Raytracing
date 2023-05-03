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
        private double _theta;
        private double _heightHalf;
        private double _widthHalf;
        private Vector _origin;
        private Vector _vectorW;
        private Vector _vectorU;
        private Vector _vectorV;
        private Vector _lowerLeftCorner;
        private Vector _horizontal;
        private Vector _vertical;

        private int _resolutionX;
        private int _resolutionY;
        private double _aspectRatio;

        private int _samplesPerPixel;
        private int _maxDepth;
        
        public Camera(Vector vectorLookFrom, Vector vectorLookAt, Vector vectorUp,int fieldOfView,int resolutionX, int resolutionY, int samplesPerPixel, int maxDepth)
        {
            _theta = (fieldOfView * Math.PI) / 180.0;
            _heightHalf = Math.Tan(_theta / 2);
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
            _aspectRatio = (double) resolutionX / (double) resolutionY;
            _widthHalf = _aspectRatio * _heightHalf;
            Origin = vectorLookFrom;
            _vectorW = vectorLookFrom.Subtract(vectorLookAt).GetUnit();
            _vectorU = vectorUp.Cross(_vectorW).GetUnit();
            _vectorV = _vectorW.Cross(_vectorU);
            LowerLeftCorner = Origin.Subtract(_vectorU.Multiply(_widthHalf)).Subtract(_vectorV.Multiply(_heightHalf)).Subtract(_vectorW);
            Horizontal = _vectorU.Multiply(2.0 * _widthHalf);
            Vertical = _vectorV.Multiply(2.0 * _heightHalf);

            SamplesPerPixel = samplesPerPixel;
            MaxDepth = maxDepth;
        }

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
        public int MaxDepth
        {
            get { return _maxDepth; }
            set { _maxDepth = value; }
        }

        public Ray GetRay(double u, double v)
        {
            Vector horizontalPosition = Horizontal.Multiply(u);
            Vector verticalPosition = Vertical.Multiply(v);

            Vector pointPosition = LowerLeftCorner.Add(horizontalPosition.Add(verticalPosition)).Subtract(Origin);

            return new Ray(Origin, pointPosition);
        }
    }
}