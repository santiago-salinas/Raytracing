using BusinessLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class PositionedModelCard : UserControl
    {
        private PositionedModel _positionedModel;
        private Model _model;
        private Scene _scene;
        public PositionedModelCard(PositionedModel providedModel, Scene providedScene)
        {
            InitializeComponent();
            _positionedModel = providedModel;
            _scene = providedScene;
            _model = _positionedModel.Model;
            modelNameLabel.Text = _model.Name;
            positionLabel.Text = _positionedModel.Position.ToString();

            LoadPreview();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _scene.RemovePositionedModel(_positionedModel);
            this.Parent.Controls.Remove(this);
        }

        private void LoadPreview()
        {
            PPM preview = _model.Preview;

            if (preview == null)
            {
                Image defaultImage = Properties.Resources.sphereImage;
                previewBox.Image = defaultImage;

                Panel coloredBox = new Panel();

                BusinessLogic.Color materialColor = _model.Material.Color;

                int redValue = (int)materialColor.Red;
                int greenValue = (int)materialColor.Green;
                int blueValue = (int)materialColor.Blue;

                System.Drawing.Color colorForBox = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
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
