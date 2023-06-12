using Controllers;
using DataTransferObjects;
using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Dialogs;
using UI.Tabs;

namespace UI.Cards
{
    public partial class EditSceneModelCard : UserControl
    {
        private SceneDTO _scene;
        private ModelDTO _model;
        private EditSceneController _controller;
        public EditSceneModelCard(EditSceneController controller, SceneDTO providedScene, ModelDTO providedModel)
        {
            InitializeComponent();
            _model = providedModel;
            _scene = providedScene;
            _controller = controller;

            modelNameLabel.Text = _model.Name;

            string shapeName = _model.Shape.Name;
            shapeNameLabel.Text += shapeName;

            string materialName = _model.Material.Name;
            materialNameLabel.Text += materialName;

            LoadPreview();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            VectorDTO position = new VectorDTO()
            {
                FirstValue = 0,
                SecondValue = 0,
                ThirdValue = 0,
            };
            EditVectorDialog editVectorDialog = new EditVectorDialog(position, "Position");
            editVectorDialog.ShowDialog();
            DialogResult result = editVectorDialog.DialogResult;

            if (result == DialogResult.OK)
            {
                PositionedModelDTO positionedModel = new PositionedModelDTO()
                {
                    ModelDTO = _model,
                    Position = position
                };
                _controller.AddPositionedModel(positionedModel, _scene);
                EditSceneTab editSceneTab = (EditSceneTab)Parent.Parent;
                editSceneTab.LoadPositionedModels();
                editSceneTab.NotifyThatSeneWasModified();
            }
        }

        private void LoadPreview()
        {
            PpmDTO preview = _model.Preview;

            if (preview == null)
            {
                Image defaultImage = Properties.Resources.sphereImage;
                previewBox.Image = defaultImage;

                Panel coloredBox = new Panel();

                ColorDTO materialColor = _model.Material.Color;

                int redValue = (int)materialColor.Red;
                int greenValue = (int)materialColor.Green;
                int blueValue = (int)materialColor.Blue;

                Color colorForBox = Color.FromArgb(redValue, greenValue, blueValue);
                coloredBox.BackColor = colorForBox;
                coloredBox.Size = new Size(40, 40);
                coloredBox.Location = new Point(previewBox.Width - coloredBox.Width, previewBox.Height - coloredBox.Height);

                previewBox.Controls.Add(coloredBox);
            }
            else
            {
                previewBox.Controls.Add(new PPMViewer(_model.Preview));
            }
        }
    }
}
