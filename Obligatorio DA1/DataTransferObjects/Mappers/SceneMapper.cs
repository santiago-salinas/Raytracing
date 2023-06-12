using BusinessLogic.Objects;
using System.Collections.Generic;

namespace DataTransferObjects
{
    public static class SceneMapper
    {
        public static SceneDTO ConvertSceneToDTO(Scene scene)
        {
            SceneDTO sceneDTO = new SceneDTO()
            {
                CameraDTO = CameraMapper.ConvertToUICamDTO(scene.CameraDTO),
                CreationDate = scene.CreationDate,
                LastModificationDate = scene.LastModificationDate,
                LastRenderDate = scene.LastRenderDate,
                Name = scene.Name,
                Owner = scene.Owner,
                PositionedModels = ConvertToDTOPosiontedModelList(scene.PositionedModels),
                Preview = PPMMapper.ConvertToDTO(scene.Preview),
                Blur = scene.Blur,
            };
            return sceneDTO;
        }
        public static Scene ConvertToScene(SceneDTO sceneDTO)
        {
            Scene scene = new Scene()
            {
                CameraDTO = CameraMapper.ConvertToDomainCamDTO(sceneDTO.CameraDTO),
                Name = sceneDTO.Name,
                Owner = sceneDTO.Owner,
                PositionedModels = ConvertToPositionedModelList(sceneDTO.PositionedModels),
                Preview = PPMMapper.ConvertToPPM(sceneDTO.Preview),

                CreationDate = sceneDTO.CreationDate,
                LastModificationDate = sceneDTO.LastModificationDate,
                LastRenderDate = sceneDTO.LastRenderDate,
                Blur = sceneDTO.Blur,
            };

            return scene;
        }

        private static List<PositionedModelDTO> ConvertToDTOPosiontedModelList(List<PositionedModel> models)
        {
            List<PositionedModelDTO> positionedModelDTOs = new List<PositionedModelDTO>();
            foreach (PositionedModel model in models)
            {
                PositionedModelDTO modelDTO = PositionedModelMapper.ConvertPositionedModelToDTO(model);
                positionedModelDTOs.Add(modelDTO);
            }

            return positionedModelDTOs;
        }
        private static List<PositionedModel> ConvertToPositionedModelList(List<PositionedModelDTO> modelDTOs)
        {
            List<PositionedModel> positionedModels = new List<PositionedModel>();
            foreach (PositionedModelDTO modelDTO in modelDTOs)
            {
                PositionedModel positionedModel = PositionedModelMapper.ConvertToPositionedModel(modelDTO);
                positionedModels.Add(positionedModel);
            }
            return positionedModels;
        }

    }
}
