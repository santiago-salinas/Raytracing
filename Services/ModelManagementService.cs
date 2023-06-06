using BusinessLogic;
using Controllers.Interfaces;
using DataTransferObjects;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;


namespace Services
{
    public class ModelManagementService
    {
        private IModelRepository _modelRepository;       

        public ModelManagementService(IModelRepository repository){
            _modelRepository = repository;
        }

        public void AddModel(ModelDTO modelDTO)
        {
            Model model = ModelMapper.ConvertToModel(modelDTO);
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

        public Model GetModel(string name, string owner)
        {
            return _modelRepository.GetModel(name, owner);
        }

        private List<ModelDTO> ConvertToModelDTOs(List<Model> models)
        {
            List<ModelDTO> modelDTOs = new List<ModelDTO>();

            foreach (Model model in models)
            {
                ModelDTO modelDTO = ModelMapper.ConvertToDTO(model);
                modelDTOs.Add(modelDTO);
            }

            return modelDTOs;
        }

        public bool ExistsModelUsingSphere(string sphereName, string sphereOwner)
        {
            Sphere sphereCopy = new Sphere()
            {
                Name = sphereName,
                Owner = sphereOwner
            };
            return _modelRepository.ExistsModelUsingTheSphere(sphereCopy);
        }

    }
}
