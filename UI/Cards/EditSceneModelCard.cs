using BusinessLogic;
using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Dialogs;
using UI.Tabs;

namespace UI.Cards
{
    public partial class EditSceneModelCard : UserControl
    {
        private Scene _scene;
        private Model _model;
        public EditSceneModelCard(Scene providedScene, Model providedModel)
        {
            InitializeComponent();
            _model = providedModel;
            _scene = providedScene;

            modelNameLabel.Text = _model.Name;

            string shapeName = _model.Shape.Name;
            shapeNameLabel.Text += shapeName;

            string materialName = _model.Material.Name;
            materialNameLabel.Text += materialName;

            LoadPreview();
        }

        private void AddButton_Click(object sender, EventArgs e)
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
                    Model = _model,
                    Position = position
                };
                _scene.AddPositionedModel(positionedModel);
                EditSceneTab editSceneTab = (EditSceneTab)Parent.Parent;
                editSceneTab.LoadPositionedModels();
                editSceneTab.NotifyThatSeneWasModified();
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
                //previewBox.Controls.Add(new PPMViewer(_model.Preview));
            }
        }
    }
}
