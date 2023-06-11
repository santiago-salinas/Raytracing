using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using DataTransferObjects;
using Services;


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
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
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
        }

        public PpmDTO RenderScene(SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastRenderDate(sceneDTO);
            PpmDTO render = RenderingService.RenderScene(sceneDTO);
            sceneDTO.Preview = render;
            return render;
        }

        public bool NameIsAlreadyInUse(string name, string owner)
        {
            return SceneManagementService.ContainsScene(name, owner);
        }
    }
}
