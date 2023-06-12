using BusinessLogic;
using System;

namespace BusinessLogic.Utilities
{
    public class Camera : ICamera
    {
        public Camera(BLCameraDTO dto)
        {
            Theta = (dto.FieldOfView * Math.PI) / 180.0;
            HeightHalf = Math.Tan(Theta / 2);
            ResolutionX = dto.ResolutionX;
            ResolutionY = dto.ResolutionY;
            AspectRatio = ResolutionX / (double)ResolutionY;
            WidthHalf = AspectRatio * HeightHalf;
            Origin = dto.LookFrom;
            VectorW = dto.LookFrom.Subtract(dto.LookAt).GetUnit();
            VectorU = dto.Up.Cross(VectorW).GetUnit();
            VectorV = VectorW.Cross(VectorU);
            LowerLeftCorner = Origin.Subtract(VectorU.Multiply(WidthHalf)).Subtract(VectorV.Multiply(HeightHalf)).Subtract(VectorW);
            Horizontal = VectorU.Multiply(2.0 * WidthHalf);
            Vertical = VectorV.Multiply(2.0 * HeightHalf);
            SamplesPerPixel = dto.SamplesPerPixel;
            MaxDepth = dto.MaxDepth;
        }

        public double Theta { get; set; }
        public double HeightHalf { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public double AspectRatio { get; set; }
        public double WidthHalf { get; set; }
        public Vector Origin { get; set; }
        public Vector VectorW { get; set; }
        public Vector VectorU { get; set; }
        public Vector VectorV { get; set; }
        public Vector LowerLeftCorner { get; set; }
        public Vector Horizontal { get; set; }
        public Vector Vertical { get; set; }

        public int SamplesPerPixel { get; set; }
        public int MaxDepth { get; set; }

        public Ray GetRay(double u, double v)
        {
            Vector horizontalPosition = Horizontal.Multiply(u);
            Vector verticalPosition = Vertical.Multiply(v);

            Vector pointPosition = LowerLeftCorner.Add(horizontalPosition.Add(verticalPosition)).Subtract(Origin);

            return new Ray(Origin, pointPosition);
        }
    }
}