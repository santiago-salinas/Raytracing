using BusinessLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class ModelCard : UserControl
    {
        private Model _model;
        public ModelCard(Model model)
        {
            InitializeComponent();
            this._model = model;
            modelNameLabel.Text = model.Name;

            string shapeName = model.Shape.Name;
            shapeNameLabel.Text += shapeName;

            string materialName = model.Material.Name;
            materialNameLabel.Text += materialName;

            LoadPreview();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                ModelRepository.RemoveModel(_model.Name, _model.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (BusinessLogicException)
            {
                deleteLabel.Visible = true;
            }
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
