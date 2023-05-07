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

namespace UI.Cards
{
    public partial class PositionedModelCard : UserControl
    {
        private PositionedModel positionedModel;
        private Model model;
        private Scene scene;
        public PositionedModelCard(PositionedModel providedModel, Scene providedScene)
        {
            InitializeComponent();
            positionedModel = providedModel;
            scene = providedScene;
            model = positionedModel.Model;
            modelNameLabel.Text = model.Name;
            positionLabel.Text = positionedModel.Position.ToString();

            loadPreview();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            scene.RemovePositionedModel(positionedModel);
            this.Parent.Controls.Remove(this);
        }

        private void loadPreview()
        {
            PPM preview = model.Preview;

            if (preview == null)
            {
                Image defaultImage = Properties.Resources.sphereImage;
                previewBox.Image = defaultImage;

                Panel coloredBox = new Panel();

                BusinessLogic.Color materialColor = model.Material.Color;

                int redValue = (int)materialColor.Red;
                int greenValue = (int)materialColor.Green;
                int blueValue = (int)materialColor.Blue;

                System.Drawing.Color colorForBox = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
                coloredBox.BackColor = colorForBox;
                coloredBox.Size = new Size(40, 40);
                coloredBox.Location = new Point(previewBox.Width - coloredBox.Width, previewBox.Height - coloredBox.Height);

                previewBox.Controls.Add(coloredBox);

            }
        }
    }
}
