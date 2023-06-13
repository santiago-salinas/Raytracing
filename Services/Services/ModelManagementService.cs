using BusinessLogic.Exceptions;
using BusinessLogic.DomainObjects;
using DataTransferObjects;
using RepoInterfaces;
using Services.Exceptions;
using System.Collections.Generic;

namespace Services
{
    public class ModelManagementService
    {
        private IModelRepository _modelRepository;
        private ISceneRepository _sceneRepository;

        public ModelManagementService(IModelRepository repository, ISceneRepository sceneRepository)
        {
            _modelRepository = repository;
            _sceneRepository = sceneRepository;
        }

        public void AddModel(ModelDTO modelDTO)
        {
            try
            {
                if (_modelRepository.ContainsModel(modelDTO.Name, modelDTO.OwnerName))
                {
                    throw new Service_ArgumentException("User already owns model with that name");
                }
                else
                {
                    Model model = ModelMapper.ConvertToModel(modelDTO);
                    _modelRepository.AddModel(model);
                }
            }
            catch (BusinessLogicException ex)
            {
                throw new Service_ArgumentException(ex.Message);
            }
        }

        public List<ModelDTO> GetModelsFromUser(string owner)
        {
            List<Model> models = _modelRepository.GetModelsFromUser(owner);
            List<ModelDTO> modelDTOs = ConvertToModelDTOs(models);

            return modelDTOs;
        }

        public void RemoveModel(string name, string owner)
        {
            if (_sceneRepository.ExistsSceneUsingModel(name, owner))
            {
                throw new Service_ObjectHandlingException("Cannot remove a model that is being used by a scene");
            }
            else
            {
                _modelRepository.RemoveModel(name, owner);
            }
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
            return _modelRepository.ExistsModelUsingTheSphere(sphereName, sphereOwner);
        }

        public bool ExistsModelUsingMaterial(string materialName, string materialOwner)
        {
            return _modelRepository.ExistsModelUsingTheMaterial(materialName, materialOwner);
        }

    }
}
