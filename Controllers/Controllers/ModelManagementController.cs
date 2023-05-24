using BusinessLogic;
using Controllers.DTOs;
using Controllers.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Controllers.Controllers
{
    public class ModelManagementController : IModelManagement
    {
        private IModelRepository _modelRepository;
        private IMaterialManagement _materialController;
        private ISphereManagement _sphereController;
        private PPMConverter _ppmConverter;

        public IModelRepository ModelRepository { set { _modelRepository = value; } }
        public IMaterialManagement MaterialController { set { _materialController = value; } }
        public ISphereManagement SphereController { set { _sphereController = value; } }
        public PPMConverter PpmConverter { set { _ppmConverter = value; } }

        public ModelManagementController()
        {    }

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

        public Model ConvertToModel(ModelDTO modelDTO)
        {
            string ownerName = modelDTO.OwnerName;
            LambertianDTO material = modelDTO.Material;
            SphereDTO shape = modelDTO.Shape;

            Model model = new Model()
            {
                Name = modelDTO.Name,
                Shape = _sphereController.GetSphere(shape.Name,ownerName),
                Material = _materialController.GetLambertian(material.Name,ownerName),
                Owner = ownerName,
                Preview = ConvertToPPM(modelDTO.Preview)
            };

            return model;
        }

        private Model GetModel(string name, string owner) 
        {
            return _modelRepository.GetModel(name,owner);
        }

        public List<LambertianDTO> GetAvailableMaterials(string owner)
        {
            return _materialController.GetLambertiansFromUser(owner);
        }

        public List<SphereDTO> GetAvailableShapes(string owner) 
        {
            return _sphereController.GetSpheresFromUser(owner);
        }

        public ModelDTO ConvertToModelDTO(Model model)
        {
            ModelDTO modelDTO = new ModelDTO()
            {
                Material = _materialController.ConvertToDTO(model.Material),
                Shape = _sphereController.ConvertToDTO(model.Shape),
                Name = model.Name,
                OwnerName = model.Owner,
                Preview = ConvertPpmToDTO(model.Preview)
            };
            return modelDTO;
        }

        private List<ModelDTO> ConvertToModelDTOs(List<Model> models)
        {
            List<ModelDTO> modelDTOs = new List<ModelDTO>();

            foreach (Model model in models)
            {
                ModelDTO modelDTO = ConvertToModelDTO(model);
                modelDTOs.Add(modelDTO);
            }

            return modelDTOs;
        }

        public PpmDTO ConvertPpmToDTO(PPM ppm) {
            return _ppmConverter.ConvertToPpmDTO(ppm);
        }

        public PPM ConvertToPPM(PpmDTO dto) {
            return _ppmConverter.ConvertToPPM(dto);
        }
    }
}
