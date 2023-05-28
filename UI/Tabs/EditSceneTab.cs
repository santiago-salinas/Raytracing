using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;
using Controllers;
using DataTransferObjects;

namespace UI.Tabs
{
    public partial class EditSceneTab : Form
    {
        private SceneDTO _scene;
        private string _loggedUser;
        public ScenesTab ScenesTab;
        private bool _isNewScene;
        private EditSceneController _controller;
        private UICameraDTO sceneCamera;
        public EditSceneTab(SceneDTO providedScene, Context context)
        {
            InitializeComponent();            
            _loggedUser = context.CurrentUser;
            _controller = context.EditSceneController;
            _isNewScene = providedScene == null;
            _scene = _isNewScene ? CreateNewScene() : providedScene;
            LoadAvailableModels();
            LoadDataFromScene(_scene);
        }

        private SceneDTO CreateNewScene()
        {
            return _controller.CreateNewScene(_loggedUser);
        }
        private void LoadDataFromScene(SceneDTO providedScene)
        {
            _scene = providedScene;
            nameTextbox.Text = providedScene.Name;
            sceneCamera = providedScene.CameraDTO;
            VectorDTO lookFrom = sceneCamera.LookFrom;
            VectorDTO lookAt = sceneCamera.LookAt;
            int fieldOfView = sceneCamera.FieldOfView;

            lookFromButton.Text = VectorToString(lookFrom);
            lookAtButton.Text = VectorToString(lookAt);

            lastModificationLabel.Text += _scene.LastModificationDate.ToString("f", new CultureInfo("en-US"));
            fovInput.Value = fieldOfView;
            if (_scene.Preview != null)
            {
                renderPanel.Controls.Add(new PPMViewer(_scene.Preview));
                lastRenderLabel.Text += _scene.LastRenderDate.ToString("f", new CultureInfo("en-US"));
            }
            LoadPositionedModels();
        }
        private void LookFromButton_Click(object sender, EventArgs e)
        {
            EditVectorDialog editVectorDialog = new EditVectorDialog(sceneCamera.LookFrom, "Look from");
            editVectorDialog.ShowDialog();
            DialogResult result = editVectorDialog.DialogResult;

            if (result == DialogResult.OK)
            {
                if (editVectorDialog.WasModified) NotifyThatSeneWasModified();
                lookFromButton.Text = VectorToString(sceneCamera.LookFrom);
            }
        }
        private void LookAtButton_Click(object sender, EventArgs e)
        {
            EditVectorDialog editVectorDialog = new EditVectorDialog(sceneCamera.LookAt, "Look at");
            editVectorDialog.ShowDialog();
            DialogResult result = editVectorDialog.DialogResult;

            if (result == DialogResult.OK)
            {
                if (editVectorDialog.WasModified) NotifyThatSeneWasModified();
                lookAtButton.Text = VectorToString(sceneCamera.LookAt);
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            nameStatusLabel.Text = "";
            string newName = nameTextbox.Text.Trim();
            bool endedCorrectly = true;

           // nameStatusLabel.Text = _controller.SaveChangedName(newName);
            

            if (endedCorrectly)
            {
                ScenesTab.LoadScenes();
                ScenesTab.Activate();
            }
        }

        private bool NameWasChanged()
        {
            return _scene.Name != nameTextbox.Text;
        }

        private void FovWasChanged(object sender, EventArgs e)
        {
            int newFov = (int)fovInput.Value;
            if (sceneCamera.FieldOfView != newFov)
            {
                NotifyThatSeneWasModified();
                sceneCamera.FieldOfView = newFov;
            }
        }
        private void LoadAvailableModels()
        {
            availableModelsPanel.Controls.Clear();
            List<ModelDTO> list = _controller.GetAvailableModels(_loggedUser);
            foreach (ModelDTO elem in list)
            {
               EditSceneModelCard modelCard = new EditSceneModelCard(_controller,_scene, elem);
               availableModelsPanel.Controls.Add(modelCard);
            }
        }
        public void LoadPositionedModels()
        {
            positionedModelsPanel.Controls.Clear();
            List<PositionedModelDTO> list = _scene.PositionedModels;
            foreach (PositionedModelDTO elem in list)
            {
                PositionedModelCard modelCard = new PositionedModelCard(elem, _scene, _controller);
                positionedModelsPanel.Controls.Add(modelCard);
            }
        }

        private void RenderButton_Click(object sender, EventArgs e)
        {
            
            renderPanel.Controls.Clear();
            outdatedStatusLabel.Visible = false;
            
            PpmDTO ppm = _controller.RenderScene(_scene);

            renderPanel.Controls.Add(new PPMViewer(ppm));
            lastRenderLabel.Text = "Last rendered: " + _scene.LastRenderDate.ToString("f", new CultureInfo("en-US"));
        }
        private string VectorToString(VectorDTO vector)
        {
            return $"({vector.FirstValue} ; {vector.SecondValue} ; {vector.ThirdValue})";
        }
        public void NotifyThatSeneWasModified()
        {            
            _controller.UpdateLastModificationDate(_scene);
            DateTime newModificationDate = _scene.LastModificationDate;
            lastModificationLabel.Text = "Last modified: " + newModificationDate.ToString("f", new CultureInfo("en-US"));
            outdatedStatusLabel.Visible = true;
        }

    }
}
