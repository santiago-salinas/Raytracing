using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utilities
{
    public class CameraBlur : ICamera
    {
        public CameraBlur(BLCameraDTO dto)
        {

            LensRadius = dto.Aperture / 2;
            FocalDistance = dto.LookAt.Subtract(dto.LookFrom).Length();

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
            LowerLeftCorner = Origin.Subtract(VectorU.Multiply(WidthHalf * FocalDistance)).Subtract(VectorV.Multiply(HeightHalf * FocalDistance)).Subtract(VectorW.Multiply(FocalDistance));
            Horizontal = VectorU.Multiply(2.0 * WidthHalf * FocalDistance);
            Vertical = VectorV.Multiply(2.0 * HeightHalf * FocalDistance);
            SamplesPerPixel = dto.SamplesPerPixel;
            MaxDepth = dto.MaxDepth;
        }

        public double LensRadius { get; set; }
        public double FocalDistance { get; set; }



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
            Vector randomVec = Vector.GetRandomInUnitSphere().Multiply(LensRadius);
            Vector offsetVec = VectorU.Multiply(randomVec.FirstValue).Add(VectorV.Multiply(randomVec.SecondValue));

            Vector horizontalPosition = Horizontal.Multiply(u);
            Vector verticalPosition = Vertical.Multiply(v);

            Vector pointPosition = LowerLeftCorner.Add(horizontalPosition.Add(verticalPosition)).Subtract(Origin).Subtract(offsetVec);

            return new Ray(Origin.Add(offsetVec), pointPosition);
        }
    }
}

