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
            SceneDTO newScene = EditSceneService.CreateNewScene(owner, name);
            AddNewScene(newScene);
            return newScene;
        }

        /*public string SaveChangedName(String newName, bool isNewScene, SceneDTO sceneDTO)
        {




            if (newName == "")
            {
                return "* Scene's name cannot be blank";
            }
            else
            {
                if (isNewScene)
                {
                    try
                    {
                        _scene.Name = newName;
                        _controller.AddNewScene(_scene);
                        endedCorrectly = true;
                    }
                    catch (Exception ex)
                    {
                        nameStatusLabel.Text = "* " + ex.Message;
                    }
                }
                else
                {
                    if (NameWasChanged() && _controller.NameIsAlreadyInUse(newName, _loggedUser))
                    {
                        nameStatusLabel.Text = "* User already owns a scene with that name";
                    }
                    else
                    {
                        _scene.Name = newName;
                        endedCorrectly = true;
                    }
                }

            }
        }
        */
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
            UpdateScene(sceneDTO);
        }

        public void AddPositionedModel(PositionedModelDTO positionedModelDTO, SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastModificationDate(sceneDTO);
            EditSceneService.AddPositionedModel(positionedModelDTO, sceneDTO);
            UpdateScene(sceneDTO);
        }
        public void UpdateLastModificationDate(SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastModificationDate(sceneDTO);
            UpdateScene(sceneDTO);
        }

        public PpmDTO RenderScene(SceneDTO sceneDTO)
        {
            EditSceneService.UpdateLastRenderDate(sceneDTO);
            PpmDTO render = RenderingService.RenderScene(sceneDTO);
            sceneDTO.Preview = render;
            UpdateScene(sceneDTO);
            return render;
        }
 
        private void UpdateScene(SceneDTO sceneDTO)
        {
            SceneManagementService.UpdateScene(sceneDTO);
        }
        public bool NameIsAlreadyInUse(string name, string owner)
        {
            return SceneManagementService.ContainsScene(name, owner);
        }
    }
}
