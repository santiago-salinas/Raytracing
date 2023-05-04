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
using BusinessLogic.Objects;
using BusinessLogic.Collections;

namespace UI.Cards
{
    public partial class ModelCard : UserControl
    {
        private Model model;
        public ModelCard(Model model)
        {
            InitializeComponent();
            this.model = model;
            modelNameLabel.Text = model.Name;
            
            string shapeName = model.ModelShape.Name;
            shapeNameLabel.Text += shapeName;

            string materialName = model.ModelColor.Name;
            materialNameLabel.Text += materialName;

            loadPreview();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                ModelCollection.RemoveModel(model.Name, model.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (BusinessLogicException ex)
            {
                deleteLabel.Visible = true;
            }
        }

        private void loadPreview()
        {
            PPM preview = model.Preview;

            if(preview == null) {
                Image defaultImage = Properties.Resources.sphereImage;
                previewBox.Image = defaultImage;
                
                Panel coloredBox = new Panel();

                BusinessLogic.Color materialColor = model.ModelColor.Color;

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
