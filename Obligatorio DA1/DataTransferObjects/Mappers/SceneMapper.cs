using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace DataTransferObjects
{
    public static class SceneMapper
    {
        public static SceneDTO ConvertSceneToDTO(Scene scene)
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
                Preview = PPMMapper.ConvertToDTO(scene.Preview)
            };
            return sceneDTO;
        }
        public static Scene ConvertToScene(SceneDTO sceneDTO)
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

        private static List<PositionedModelDTO> ConvertToDTOPosiontedModelList(List<PositionedModel> models)
        {
            List<PositionedModelDTO> positionedModelDTOs = new List<PositionedModelDTO>();
            foreach (PositionedModel model in models)
            {
                PositionedModelDTO modelDTO = ConvertPositionedModelToDTO(model);
                positionedModelDTOs.Add(modelDTO);
            }

            return positionedModelDTOs;
        }
        private static List<PositionedModel> ConvertToPositionedModelList(List<PositionedModelDTO> modelDTOs)
        {
            List<PositionedModel> positionedModels = new List<PositionedModel>();
            foreach (PositionedModelDTO modelDTO in modelDTOs)
            {
                PositionedModel positionedModel = ConvertToPositionedModel(modelDTO);
                positionedModels.Add(positionedModel);
            }
            return positionedModels;
        }

        private static PositionedModelDTO ConvertPositionedModelToDTO(PositionedModel positionedModel)
        {
            PositionedModelDTO positionedModelDTO = new PositionedModelDTO()
            {
                ModelDTO = ModelMapper.ConvertToDTO(positionedModel.Model),
                Position = ConvertVectorToDTO(positionedModel.Position),
            };

            return positionedModelDTO;
        }
        private static PositionedModel ConvertToPositionedModel(PositionedModelDTO positionedModelDTO)
        {
            PositionedModel positionedModel = new PositionedModel()
            {
                Model = ModelMapper.ConvertToModel(positionedModelDTO.ModelDTO),
                Position = ConvertToVector(positionedModelDTO.Position),
            };

            return positionedModel;
        }

        private static Vector ConvertToVector(VectorDTO vectorDTO)
        {
            Vector vector = new Vector()
            {
                FirstValue = vectorDTO.FirstValue,
                SecondValue = vectorDTO.SecondValue,
                ThirdValue = vectorDTO.ThirdValue,
            };

            return vector;
        }
        private static VectorDTO ConvertVectorToDTO(Vector vector)
        {
            VectorDTO vectorDTO = new VectorDTO()
            {
                FirstValue = vector.FirstValue,
                SecondValue = vector.SecondValue,
                ThirdValue = vector.ThirdValue
            };

            return vectorDTO;
        }
    }
}
