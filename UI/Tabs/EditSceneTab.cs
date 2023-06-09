﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
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

        private PPMViewer _imagePPM;

        private EditSceneController _controller;
        private UICameraDTO sceneCamera;

        public EditSceneTab(SceneDTO providedScene, Context context)
        {
            InitializeComponent();
            _loggedUser = context.CurrentUser;
            _controller = context.EditSceneController;
            _isNewScene = providedScene == null;
            _scene = providedScene;

            if (!_isNewScene)
            {
                EnableEditControls();
            }
        }

        private SceneDTO CreateNewScene(string name)
        {
            return _controller.CreateNewScene(_loggedUser,name);
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
                _imagePPM = new PPMViewer(_scene.Preview);
                renderPanel.Controls.Add(_imagePPM);
                saveBtn.Enabled = true;
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

            _scene = CreateNewScene(newName);

            EnableEditControls();
            
        }

        private void EnableEditControls()
        {
            lookFromButton.Enabled = true;
            lookAtButton.Enabled = true;
            fovInput.Enabled = true;
            checkBlur.Enabled = true;
            renderButton.Enabled = true;

            saveButton.Visible = false;
            nameTextbox.ReadOnly = true;

            LoadAvailableModels();
            LoadDataFromScene(_scene);
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

            _imagePPM = new PPMViewer(ppm);

            renderPanel.Controls.Add(_imagePPM);
            saveBtn.Enabled = true;

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

        private void numericAperture_ValueChanged(object sender, EventArgs e)
        {
            double newAperture = (double) apertureInput.Value;
            if (sceneCamera.Aperture != newAperture)
            {
                NotifyThatSeneWasModified();
                sceneCamera.Aperture = newAperture;
            }
        }

        private void checkBlur_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBlur_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBlur.Checked)
            {
                apertureInput.Enabled = true;
                _scene.Blur = true;
            }
            else
            {
                apertureInput.Enabled = false;
                _scene.Blur = false;
            }
            NotifyThatSeneWasModified();
        }

        // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-save-files-using-the-savefiledialog-component?view=netframeworkdesktop-4.8
        private void button1_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Png Image|*.png|Ppm Image|*.ppm";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this._imagePPM.GetImage().Save(fs,System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this._imagePPM.GetImage().Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 3:
                        this._imagePPM.SavePPM(fs);
                        break;
                }

                fs.Close();
            }
        }
    }
}
