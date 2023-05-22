using BusinessLogic;
using Controllers.DTOs;
using Controllers.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    public class ModelManagementController
    {
        private IModelRepository _modelRepository;
        private IMaterialManagement _materialController;
        private ISphereManagement _sphereController;


        public ModelManagementController(IModelRepository modelRepository, ISphereManagement sphereController, IMaterialManagement materialController)
        {
            _modelRepository = modelRepository;
            _sphereController = sphereController;
            _materialController = materialController;
        }

        public void AddModel(ModelDTO modelDTO)
        {
            Model model = ConvertToModel(modelDTO);
            _modelRepository.AddModel(model);
        }

        public List<ModelDTO> GetModelsFromUser(string owner)
        {
            List<Model> models = _modelRepository.GetModelsFromUser(owner);
            List<ModelDTO> modelDTOs = ConvertToModelDTOs(models);

            return modelDTOs;
        }

        public void RemoveModel(string name, string owner)
        {
            _modelRepository.RemoveModel(name, owner);
        }

        private Model ConvertToModel(ModelDTO modelDTO)
        {
            string ownerName = modelDTO.OwnerName;
            string materialName = modelDTO.MaterialName;
            string shapeName = modelDTO.ShapeName;

            Model model = new Model()
            {
                Name = modelDTO.Name,
                Material = _materialController.GetLambertian(materialName,ownerName),
                Shape = _sphereController.GetSphere(shapeName,ownerName),
                Owner = ownerName,
                Preview = modelDTO.Preview
            };

            return model;
        }

        private ModelDTO ConvertToModelDTO(Model model)
        {
            ModelDTO modelDTO = new ModelDTO()
            {
                MaterialName = model.Material.Name,
                ShapeName = model.Shape.Name,
                Name = model.Name,
                OwnerName = model.Owner,
                Preview = model.Preview
            };
            return modelDTO;
        }

        private List<ModelDTO> ConvertToModelsDTOs(List<Model> models)
        {
            List<ModelDTO> modelDTOs = new List<ModelDTO>();

            foreach (Model model in models)
            {
                ModelDTO modelDTO = ConvertToModelDTO(model);
                modelDTOs.Add(modelDTO);
            }

            return modelDTOs;
        }
    }
}
