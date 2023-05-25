using BusinessLogic;
using Controllers.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public static class ModelMapper
    {
        public static ModelDTO ConvertToDTO(Model model)
        {
            ModelDTO modelDTO = new ModelDTO()
            {
                Material = MaterialMapper.ConvertToDTO(model.Material),
                Shape = SphereMapper.ConvertToDTO(model.Shape),
                Name = model.Name,
                OwnerName = model.Owner,
                Preview = PPMMapper.ConvertToDTO(model.Preview)
            };
            return modelDTO;
        }

        public static Model ConvertToModel(ModelDTO modelDTO)
        {
            string ownerName = modelDTO.OwnerName;
            LambertianDTO material = modelDTO.Material;
            SphereDTO shape = modelDTO.Shape;

            Model model = new Model()
            {
                Name = modelDTO.Name,
                Shape = SphereMapper.ConvertToSphere(shape),
                Material = MaterialMapper.ConvertToLambertian(material),
                Owner = ownerName,
                Preview = PPMMapper.ConvertToPPM(modelDTO.Preview)
            };

            return model;
        }
    }
}
