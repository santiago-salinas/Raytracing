using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using UI.Dialogs;
using UI.Tabs;

namespace UI.Cards
{
    public partial class EditSceneModelCard : UserControl
    {
        private Scene scene;
        private Model model;
        public EditSceneModelCard(Scene providedScene, Model providedModel)
        {
            InitializeComponent();
            model = providedModel;
            scene = providedScene;
            
            modelNameLabel.Text = model.Name;

            string shapeName = model.ModelShape.Name;
            shapeNameLabel.Text += shapeName;

            string materialName = model.ModelColor.Name;
            materialNameLabel.Text += materialName;

            loadPreview();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Vector position = new Vector()
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
                PositionedModel positionedModel = new PositionedModel()
                {
                    PositionedModelModel = model,
                    PositionedModelPosition = position
                };
                scene.AddPositionedModel(positionedModel);
                EditSceneTab editSceneTab = (EditSceneTab)Parent.Parent;
                editSceneTab.loadPositionedModels();
                editSceneTab.notifyThatSeneWasModified();
            }
        }

        private void loadPreview()
        {
            PPM preview = model.Preview;

            if (preview == null)
            {
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
            else
            {
                previewBox.Controls.Add(new PPMViewer(model.Preview));
            }
        }
    }
}
