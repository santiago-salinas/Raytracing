using BusinessLogic;
using Controllers.Interfaces;
using Repositories.Interfaces;
using System.Collections.Generic;
using DataTransferObjects;

namespace Controllers
{
    public class SceneManagementController
    {
        private ISceneRepository _sceneRepository;
        private IModelManagement _modelController;

        public SceneManagementController(ISceneRepository sceneRepository, IModelManagement modelController)
        {
            _sceneRepository = sceneRepository;
            _modelController = modelController;
        }

        private SceneDTO ConvertSceneToDTO(Scene scene)
        {
            SceneDTO sceneDTO = new SceneDTO()
            {
                CameraDTO = scene.CameraDTO,
                CreationDate = scene.CreationDate,
                LastModificationDate = scene.LastModificationDate,
                LastRenderDate = scene.LastRenderDate,
                Name = scene.Name,
                Owner = scene.Owner,
                PositionedModels = ConvertToDTOPosiontedModelList(scene.PositionedModels),
                Preview = _modelController.ConvertPpmToDTO(scene.Preview)                
            };
            return sceneDTO;
        }
        private Scene ConvertToScene(SceneDTO sceneDTO)
        {
            Scene scene = new Scene()
            {
                CameraDTO = sceneDTO.CameraDTO,
                Name = sceneDTO.Name,
                Owner = sceneDTO.Owner,
                PositionedModels = ConvertToPositionedModelList(sceneDTO.PositionedModels)
            };

            return scene;
        }
        private List<PositionedModelDTO> ConvertToDTOPosiontedModelList(List<PositionedModel> models)
        {
            List<PositionedModelDTO> positionedModelDTOs = new List<PositionedModelDTO>();
            foreach (PositionedModel model in models)
            {
                PositionedModelDTO modelDTO = ConvertPositionedModelToDTO(model);
                positionedModelDTOs.Add(modelDTO);
            }

            return positionedModelDTOs;
        }
        private List<PositionedModel> ConvertToPositionedModelList(List<PositionedModelDTO> modelDTOs) {
            List<PositionedModel> positionedModels = new List<PositionedModel>();
            foreach(PositionedModelDTO modelDTO in modelDTOs)
            {
                PositionedModel positionedModel = ConvertToPositionedModel(modelDTO);
                positionedModels.Add(positionedModel);
            }
            return positionedModels;        
        }

        private PositionedModelDTO ConvertPositionedModelToDTO(PositionedModel positionedModel)
        {
            PositionedModelDTO positionedModelDTO = new PositionedModelDTO()
            {
                ModelDTO = _modelController.ConvertToModelDTO(positionedModel.Model),
                Position = ConvertVectorToDTO(positionedModel.Position),
            };

            return positionedModelDTO;
        }
        private PositionedModel ConvertToPositionedModel(PositionedModelDTO positionedModelDTO)
        {
            PositionedModel positionedModel = new PositionedModel()
            {
                Model = _modelController.ConvertToModel(positionedModelDTO.ModelDTO),
                Position = ConvertToVector(positionedModelDTO.Position),
            };

            return positionedModel;
        }

        private Vector ConvertToVector(VectorDTO vectorDTO)
        {
            Vector vector = new Vector()
            {
                FirstValue = vectorDTO.FirstValue,
                SecondValue = vectorDTO.SecondValue,
                ThirdValue = vectorDTO.ThirdValue,
            };

            return vector;
        }
        private VectorDTO ConvertVectorToDTO(Vector vector)
        {
            VectorDTO vectorDTO = new VectorDTO()
            {
                FirstValue = vector.FirstValue,
                SecondValue = vector.SecondValue,
                ThirdValue = vector.ThirdValue
            };

            return vectorDTO;
        }
        public List<SceneDTO> GetScenesFromUser(string owner)
        {
            List<Scene> scenes = _sceneRepository.GetScenesFromUser(owner);
            List<SceneDTO> sceneDTOs = new List<SceneDTO>();

            foreach(Scene scene in scenes)
            {
                SceneDTO sceneDTO = ConvertSceneToDTO(scene);
                sceneDTOs.Add(sceneDTO);
            }

            return sceneDTOs;
        }

        public bool ContainsScene(string name, string owner)
        {
            return _sceneRepository.ContainsScene(name, owner);
        }

        public void AddScene(SceneDTO newElement)
        {
            Scene newScene = ConvertToScene(newElement);
            _sceneRepository.AddScene(newScene);
        }

        public Scene GetScene(string name, string owner)
        {
            return _sceneRepository.GetScene(name, owner);
        }

        public void RemoveScene(string name, string owner)
        {
            _sceneRepository.RemoveScene(name, owner);
        }

    }
}
