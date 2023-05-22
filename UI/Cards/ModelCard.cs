using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using Controllers.DTOs;
using Controllers.Controllers;


namespace UI.Cards
{
    public partial class ModelCard : UserControl
    {
        private ModelDTO _model;
        private ModelManagementController _controller;
        public ModelCard(ModelDTO model, ModelManagementController controller)
        {
            InitializeComponent();
            _controller = controller;

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
                _controller.RemoveModel(_model.Name, _model.OwnerName);
                this.Parent.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                deleteLabel.Text = ex.Message;
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

                System.Drawing.Color colorForBox = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
                coloredBox.BackColor = colorForBox;
                coloredBox.Size = new Size(40, 40);
                coloredBox.Location = new Point(previewBox.Width - coloredBox.Width, previewBox.Height - coloredBox.Height);

                previewBox.Controls.Add(coloredBox);
            }
            else
            {
                //previewBox.Controls.Add(new PPMViewer(_model.Preview));
            }
        }
    }
}
