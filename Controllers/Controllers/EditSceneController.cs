using Controllers.Exceptions;
using DataTransferObjects.DTOs;
using Services;
using Services.Exceptions;
using System.Collections.Generic;


namespace Controllers
{
    public class EditSceneController
    {
        public EditSceneService EditSceneService { get; set; }
        public RenderingService RenderingService { get; set; }
        public ModelManagementService ModelManagementService { get; set; }
        public SceneManagementService SceneManagementService { get; set; }
        public EditSceneController() { }
        public SceneDTO CreateNewScene(string owner, string name)
        {
            try
            {
                SceneDTO newScene = EditSceneService.CreateNewScene(owner, name);
                AddNewScene(newScene);
                return newScene;
            }
            catch (Service_ArgumentException ex)
            {
                throw new Controller_ArgumentException(ex.Message);
            }

        }

        public List<ModelDTO> GetAvailableModels(string owner)
        {
            return ModelManagementService.GetModelsFromUser(owner);
        }

        public void AddNewScene(SceneDTO sceneDTO)
        {
            SceneManagementService.AddScene(sceneDTO);
        }
        public void RemovePositionedModel(PositionedModelDTO positionedModelDTO, SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastModificationDate(sceneDTO);
            EditSceneService.RemovePositionedModel(positionedModelDTO, sceneDTO);
        }

        public void AddPositionedModel(PositionedModelDTO positionedModelDTO, SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastModificationDate(sceneDTO);
            EditSceneService.AddPositionedModel(positionedModelDTO, sceneDTO);
        }
        public void UpdateLastModificationDate(SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastModificationDate(sceneDTO);
        }

        public void UpdateRenderDate(SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastRenderDate(sceneDTO);
        }


        public void UpdateCamera(SceneDTO sceneDTO)
        {
            EditSceneService.UpdateCamera(sceneDTO);
            EditSceneService.UpdateBlurSetting(sceneDTO);
        }

        public void UpdateBlur(SceneDTO sceneDTO)
        {
            EditSceneService.UpdateBlur(sceneDTO);
        }

        public PpmDTO RenderScene(SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastRenderDate(sceneDTO);
            PpmDTO render = RenderingService.RenderScene(sceneDTO);
            sceneDTO.Preview = render;
            EditSceneService.UpdatePreview(sceneDTO);
            return render;
        }

    }
}
