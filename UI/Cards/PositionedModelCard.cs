using Controllers;
using DataTransferObjects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class PositionedModelCard : UserControl
    {
        private PositionedModelDTO _positionedModel;
        private ModelDTO _model;
        private SceneDTO _scene;
        private EditSceneController _controller;
        public PositionedModelCard(PositionedModelDTO providedModel, SceneDTO providedScene, EditSceneController controller)
        {
            InitializeComponent();
            _positionedModel = providedModel;
            _scene = providedScene;
            _model = _positionedModel.ModelDTO;
            _controller = controller;
            modelNameLabel.Text = _model.Name;
            positionLabel.Text = VectorToString(providedModel.Position);

            LoadPreview();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _controller.RemovePositionedModel(_positionedModel, _scene);
            this.Parent.Controls.Remove(this);
        }        

        private string VectorToString(VectorDTO vector)
        {
            return $"({vector.FirstValue} ; {vector.SecondValue} ; {vector.ThirdValue})";
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
