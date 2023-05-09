using BusinessLogic;
using System;
using System.Globalization;
using System.Windows.Forms;
using UI.Tabs;

namespace UI.Cards
{
    public partial class SceneCard : UserControl
    {
        private Scene thisScene;

        public SceneCard(Scene scene)
        {
            InitializeComponent();
            thisScene = scene;
            loadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Scenes.RemoveScene(thisScene.Name, thisScene.Owner);
            this.Parent.Controls.Remove(this);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            ScenesTab scenesTab = this.Parent.Parent as ScenesTab;
            scenesTab.loadSceneEditTab(thisScene);
        }

        private void loadData()
        {
            nameLabel.Text = thisScene.Name;
            lastModificationLabel.Text += thisScene.LastModificationDate.ToString("f", new CultureInfo("en-US"));
            if (thisScene.Preview == null)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Properties.Resources.no_img_placeholder;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                previewPanel.Controls.Add(pictureBox);
                pictureBox.Dock = DockStyle.Fill;
            }
            else
            {
                previewPanel.Controls.Clear();
                previewPanel.Controls.Add(new PPMViewer(thisScene.Preview));
            }
        }
    }
}
