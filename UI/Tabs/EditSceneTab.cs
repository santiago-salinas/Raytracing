using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class EditSceneTab : Form
    {
        private Scene _scene;
        private User _loggedUser;
        public ScenesTab ScenesTab;
        private bool _isNewScene;

        private PPMViewer _imagePPM;

        private CameraDTO sceneCamera;
        public EditSceneTab(Scene providedScene, User providedUser)
        {
            InitializeComponent();
            _loggedUser = providedUser;
            _isNewScene = providedScene == null;
            _scene = _isNewScene ? CreateNewScene() : providedScene;
            LoadAvailableModels();
            LoadDataFromScene(_scene);
        }

        private Scene CreateNewScene()
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
                SamplesPerPixel = 50,

                Aperture = 1.0
            };

            Scene newScene = new Scene()
            {
                Owner = _loggedUser,
                CameraDTO = defaultCameraValues,
            };

            return newScene;
        }
        private void LoadDataFromScene(Scene providedScene)
        {
            _scene = providedScene;
            nameTextbox.Text = providedScene.Name;
            sceneCamera = providedScene.CameraDTO;
            Vector lookFrom = sceneCamera.LookFrom;
            Vector lookAt = sceneCamera.LookAt;
            int fieldOfView = sceneCamera.FieldOfView;
            lookFromButton.Text = lookFrom.ToString();
            lookAtButton.Text = lookAt.ToString();
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
                lookFromButton.Text = sceneCamera.LookFrom.ToString();
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
                lookAtButton.Text = sceneCamera.LookAt.ToString();
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
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
                if (_isNewScene)
                {
                    try
                    {
                        _scene.Name = newName;
                        Scenes.AddScene(_scene);
                        endedCorrectly = true;
                    }
                    catch (Exception ex)
                    {
                        nameStatusLabel.Text = "* " + ex.Message;
                    }
                }
                else
                {
                    if (NameWasChanged() && Scenes.ContainsScene(newName, _loggedUser))
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
            List<Model> list = Models.GetModelsFromUser(_loggedUser);
            foreach (Model elem in list)
            {
                EditSceneModelCard modelCard = new EditSceneModelCard(_scene, elem);
                availableModelsPanel.Controls.Add(modelCard);
            }
        }

        public void LoadPositionedModels()
        {
            positionedModelsPanel.Controls.Clear();
            List<PositionedModel> list = _scene.PositionedModels;
            foreach (PositionedModel elem in list)
            {
                PositionedModelCard modelCard = new PositionedModelCard(elem, _scene);
                positionedModelsPanel.Controls.Add(modelCard);
            }
        }

        private void RenderButton_Click(object sender, EventArgs e)
        {
            _scene.UpdateLastRenderDate();
            lastRenderLabel.Text = "Last rendered: " + _scene.LastRenderDate.ToString("f", new CultureInfo("en-US"));
            renderPanel.Controls.Clear();
            outdatedStatusLabel.Visible = false;

            Engine engine = new Engine(_scene);
            PPM ppm = engine.Render();
            _scene.Preview = ppm;

            _imagePPM = new PPMViewer(ppm);

            renderPanel.Controls.Add(_imagePPM);
            saveBtn.Enabled = true;

        }

        public void NotifyThatSeneWasModified()
        {            
            _scene.UpdateLastModificationDate();
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
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Png Image|*.png|Ppm Image (25segundos)|*.ppm";
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
