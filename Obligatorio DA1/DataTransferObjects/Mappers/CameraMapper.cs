using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public static class CameraMapper
    {
        public static UICameraDTO ConvertToUICamDTO(BLCameraDTO providedDTO)
        {
            UICameraDTO uiCamera = new UICameraDTO()
            {
                FieldOfView = providedDTO.FieldOfView,
                LookAt = VectorMapper.ConvertToDTO(providedDTO.LookAt),
                LookFrom = VectorMapper.ConvertToDTO(providedDTO.LookFrom),
                MaxDepth = providedDTO.MaxDepth,
                ResolutionX = providedDTO.ResolutionX,
                ResolutionY = providedDTO.ResolutionY,
                SamplesPerPixel = providedDTO.SamplesPerPixel,
                Up = VectorMapper.ConvertToDTO(providedDTO.Up)                
            };

            return uiCamera;
        }

        public static BLCameraDTO ConvertToDomainCamDTO(UICameraDTO providedDTO)
        {
            BLCameraDTO domainDTO = new BLCameraDTO()
            {
                FieldOfView = providedDTO.FieldOfView,
                LookAt = VectorMapper.ConvertToVector(providedDTO.LookAt),
                LookFrom = VectorMapper.ConvertToVector(providedDTO.LookFrom),
                MaxDepth = providedDTO.MaxDepth,
                ResolutionX = providedDTO.ResolutionX,
                ResolutionY = providedDTO.ResolutionY,
                SamplesPerPixel = providedDTO.SamplesPerPixel,
                Up = VectorMapper.ConvertToVector(providedDTO.Up)
            };

            return domainDTO;
        }
    }
}
