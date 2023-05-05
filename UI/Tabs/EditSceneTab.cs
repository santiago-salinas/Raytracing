using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Dialogs;
using UI.Cards;

namespace UI.Tabs
{
    public partial class EditSceneTab : Form
    {
        public Scene scene;
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
                LookFrom = new Vector(0,2,0),
                LookAt = new Vector(0,2,5),
                Up = new Vector(0, 1, 0),
                FieldOfView = 30,                
                MaxDepth = 50,
                ResolutionX = 650,
                ResolutionY = 375,
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
        public void loadDataFromScene(Scene providedScene)
        {
 
            scene = providedScene;               
            nameTextbox.Text = providedScene.Name;
            sceneCamera = providedScene.CameraDTO;
            Vector lookFrom = sceneCamera.LookFrom;
            Vector lookAt = sceneCamera.LookAt;
            int fieldOfView = sceneCamera.FieldOfView;
            editLookFromButtonText(lookFrom);
            editLookAtButtonText(lookAt);  
            lastModificationLabel.Text += scene.LastModificationDate.ToString("f");
            //renderPanel.Controls.Add(new PPMViewer(scene.Preview));
            loadPositionedModels();            
        }
        private void lookFromEditButton_Click(object sender, EventArgs e)
        {
            
            EditVectorDialog editVectorDialog = new EditVectorDialog(sceneCamera.LookFrom);
            editVectorDialog.ShowDialog();  
            DialogResult result = editVectorDialog.DialogResult;

            if(result == DialogResult.OK)
            {
                editLookFromButtonText(sceneCamera.LookFrom);
                notifyThatSeneWasModified();
            } 
        }

        private void editLookFromButtonText(Vector lookFromValues)
        {
            lookFromButton.Text = "(" + lookFromValues.FirstValue + "," + lookFromValues.SecondValue + "," + lookFromValues.ThirdValue + ")";
        }

        private void lookAtButton_Click(object sender, EventArgs e)
        {
            EditVectorDialog editVectorDialog = new EditVectorDialog(sceneCamera.LookAt);
            editVectorDialog.ShowDialog();
            DialogResult result = editVectorDialog.DialogResult;

            if (result == DialogResult.OK)
            {
                editLookAtButtonText(sceneCamera.LookAt);
                notifyThatSeneWasModified();
            }
        }

        private void editLookAtButtonText(Vector lookAtValues)
        {
            lookAtButton.Text = "(" + lookAtValues.FirstValue + "," + lookAtValues.SecondValue + "," + lookAtValues.ThirdValue + ")";
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            nameStatusLabel.Text = string.Empty;
            string newName = nameTextbox.Text.Trim();
            bool endedCorrectly = false;
            if(newName == "")
            {
                nameStatusLabel.Text = "* Scene's name cannot be blank";
            }
            else
            {

                if (isNewScene)
                {
                    if (SceneCollection.ContainsScene(newName, loggedUser))
                    {
                        nameStatusLabel.Text = "* User already owns a scene with that name";
                    }
                    else
                    {
                        scene.Name = newName;
                        SceneCollection.AddScene(scene);
                        endedCorrectly = true;
                    }
                }
                else
                { 
                    if(nameWasChanged() && SceneCollection.ContainsScene(newName, loggedUser))
                    {
                        nameStatusLabel.Text = "* User already owns a scene with that name";
                    }
                    else
                    {
                        scene.Name = newName;
                        endedCorrectly= true;
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

        private void loadAvailableModels()
        {
            List<Model> list = ModelCollection.GetModelsFromUser(loggedUser);
            foreach (Model elem in list)
            {
                ModelCard modelCard = new ModelCard(elem);
                availableModelsPanel.Controls.Add(modelCard);
            }
        }

        private void loadPositionedModels()
        {
           
            List<PositionedModel> list = scene.PositionedModels;
            foreach (PositionedModel elem in list)
            {
               PositionedModelCard modelCard = new PositionedModelCard(elem, scene);
               positionedModelsPanel.Controls.Add(modelCard);
            }                                   
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            DateTime newRenderDate = DateTime.Now;
            scene.LastRenderDate = newRenderDate;
            lastRenderLabel.Text = "Last rendered: " + newRenderDate.ToString("f");
            renderPanel.Controls.Clear();
            outdatedStatusLabel.Visible = false;
            

            Camera camera = new Camera(scene.CameraDTO);
            Motor motomoto = new Motor(scene, camera);
            PPM ppm = motomoto.render();
            scene.Preview = ppm;

            renderPanel.Controls.Add(new PPMViewer(ppm));
        }

        private void notifyThatSeneWasModified()
        {
            DateTime newModificationDate = DateTime.Now;
            scene.LastModificationDate = newModificationDate;
            lastModificationLabel.Text = "Last modification date: " + newModificationDate.ToString("f");
            outdatedStatusLabel.Visible = true;
        }
    }
}
