using BusinessLogic.Utilities;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class CameraEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Vector LookFrom { get; set; }
        public Vector LookAt { get; set; }
        public Vector Up { get; set; }
        public int FieldOfView { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public int SamplesPerPixel { get; set; }
        public int MaxDepth { get; set; }
        public double Aperture { get; set; }

        public static BLCameraDTO FromEntity(CameraEntity entity)
        {
            BLCameraDTO ret = new BLCameraDTO()
            {
                LookFrom = entity.LookFrom,
                LookAt = entity.LookAt,
                Up = entity.Up,
                FieldOfView = entity.FieldOfView,
                ResolutionX = entity.ResolutionX,
                ResolutionY = entity.ResolutionY,
                SamplesPerPixel = entity.SamplesPerPixel,
                MaxDepth = entity.MaxDepth,
                Aperture = entity.Aperture
            };
            return ret;
        }

        public static CameraEntity FromDomain(BLCameraDTO camera)
        {
            return new CameraEntity()
            {
                Id = Guid.NewGuid(),
                LookFrom = camera.LookFrom,
                LookAt = camera.LookAt,
                Up = camera.Up,
                FieldOfView = camera.FieldOfView,
                ResolutionX = camera.ResolutionX,
                ResolutionY = camera.ResolutionY,
                SamplesPerPixel = camera.SamplesPerPixel,
                MaxDepth = camera.MaxDepth,
                Aperture = camera.Aperture
            };
        }
    }
}
