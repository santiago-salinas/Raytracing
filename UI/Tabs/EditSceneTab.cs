using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class EditSceneTab : Form
    {
        private Scene scene;
        private User loggedUser;
        public ScenesTab scenesTab;
        private bool isNewScene;

        private CameraDTO sceneCamera;
        public EditSceneTab(Scene providedScene, User providedUser)
        {
            InitializeComponent();
            loggedUser = providedUser;
            isNewScene = providedScene == null;
            scene = isNewScene ? createNewScene() : providedScene;
            loadAvailableModels();
            loadDataFromScene(scene);           
        }

        private Scene createNewScene()
        {
            CameraDTO defaultCameraValues = new CameraDTO()
            {
                LookFrom = new Vector(0, 2, 0),
                LookAt = new Vector(0, 2, 5),
                Up = new Vector(0, 1, 0),
                FieldOfView = 30,
                MaxDepth = 20,
                ResolutionX = 300,
                ResolutionY = 200,
                SamplesPerPixel = 50
            };

            Scene newScene = new Scene()
            {
                Owner = loggedUser,
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                CameraDTO = defaultCameraValues,
            };
            
            return newScene;
        }
        private void loadDataFromScene(Scene providedScene)
        {
            scene = providedScene;
            nameTextbox.Text = providedScene.Name;
            sceneCamera = providedScene.CameraDTO;
            Vector lookFrom = sceneCamera.LookFrom;
            Vector lookAt = sceneCamera.LookAt;
            int fieldOfView = sceneCamera.FieldOfView;
            lookFromButton.Text = lookFrom.ToString();
            lookAtButton.Text = lookAt.ToString();
            lastModificationLabel.Text += scene.LastModificationDate.ToString("f", new CultureInfo("en-US"));
            fovInput.Value = fieldOfView;
            if (scene.Preview != null)
            {
                renderPanel.Controls.Add(new PPMViewer(scene.Preview));
                lastRenderLabel.Text += scene.LastRenderDate.ToString("f", new CultureInfo("en-US"));
            }
            loadPositionedModels();            
        }
        private void lookFromButton_Click(object sender, EventArgs e)
        {

            EditVectorDialog editVectorDialog = new EditVectorDialog(sceneCamera.LookFrom, "Look from");
            editVectorDialog.ShowDialog();
            DialogResult result = editVectorDialog.DialogResult;

            if(result == DialogResult.OK)
            {
                if (editVectorDialog.wasModified) notifyThatSeneWasModified();
                lookFromButton.Text = sceneCamera.LookFrom.ToString();
            } 
        }
        private void lookAtButton_Click(object sender, EventArgs e)
        {
            EditVectorDialog editVectorDialog = new EditVectorDialog(sceneCamera.LookAt,"Look at");
            editVectorDialog.ShowDialog();
            DialogResult result = editVectorDialog.DialogResult;

            if (result == DialogResult.OK) { 
                if (editVectorDialog.wasModified) notifyThatSeneWasModified();
                lookAtButton.Text = sceneCamera.LookAt.ToString();                
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            nameStatusLabel.Text = string.Empty;
            string newName = nameTextbox.Text.Trim();
            bool endedCorrectly = false;
            if (newName == "")
            {
                nameStatusLabel.Text = "* Scene's name cannot be blank";
            }
            else
            {

                if (isNewScene)
                {
                    if (Scenes.ContainsScene(newName, loggedUser))
                    {
                        nameStatusLabel.Text = "* User already owns a scene with that name";
                    }
                    else
                    {
                        scene.Name = newName;
                        Scenes.AddScene(scene);
                        endedCorrectly = true;
                    }
                }
                else
                {
                    if (nameWasChanged() && Scenes.ContainsScene(newName, loggedUser))
                    {
                        nameStatusLabel.Text = "* User already owns a scene with that name";
                    }
                    else
                    {
                        scene.Name = newName;
                        endedCorrectly = true;
                    }
                }

            }

            if (endedCorrectly)
            {
                scenesTab.loadScenes();
                scenesTab.Activate();
            }
        }

        private bool nameWasChanged()
        {
            return scene.Name != nameTextbox.Text;
        }

        private void fovWasChanged(object sender, EventArgs e)
        {
            int newFov = (int)fovInput.Value;
            if (sceneCamera.FieldOfView != newFov) {
                notifyThatSeneWasModified();
                sceneCamera.FieldOfView = newFov;
            }
        }
        private void loadAvailableModels()
        {
            availableModelsPanel.Controls.Clear();
            List<Model> list = Models.GetModelsFromUser(loggedUser);
            foreach (Model elem in list)
            {
                EditSceneModelCard modelCard = new EditSceneModelCard(scene, elem);
                availableModelsPanel.Controls.Add(modelCard);
            }
        }

        public void loadPositionedModels()
        {
            positionedModelsPanel.Controls.Clear();
            List<PositionedModel> list = scene.PositionedModels;
            foreach (PositionedModel elem in list)
            {
                PositionedModelCard modelCard = new PositionedModelCard(elem, scene);
                positionedModelsPanel.Controls.Add(modelCard);
            }
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            scene.UpdateLastRenderDate();
            lastRenderLabel.Text = "Last rendered: " + scene.LastRenderDate.ToString("f", new CultureInfo("en-US"));
            renderPanel.Controls.Clear();
            outdatedStatusLabel.Visible = false;
            
            Engine engine = new Engine(scene);
            PPM ppm = engine.Render();
            scene.Preview = ppm;

            renderPanel.Controls.Add(new PPMViewer(ppm));
        }

        public void notifyThatSeneWasModified()
        {
            DateTime newModificationDate = DateTime.Now;
            scene.LastModificationDate = newModificationDate;
            lastModificationLabel.Text = "Last modification date: " + newModificationDate.ToString("f", new CultureInfo("en-US"));
            outdatedStatusLabel.Visible = true;
        }

    }
}
