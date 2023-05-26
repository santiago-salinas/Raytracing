using System;
using System.Globalization;
using System.Windows.Forms;
using UI.Tabs;
using Controllers;
using DataTransferObjects;

namespace UI.Cards
{
    public partial class SceneCard : UserControl
    {
        private SceneDTO _thisScene;        
        private SceneManagementController _controller;

        public SceneCard(SceneManagementController controller, SceneDTO scene)
        {
            InitializeComponent();
            _thisScene = scene;
            _controller = controller;
            LoadData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _controller.RemoveScene(_thisScene.Name, _thisScene.Owner);
            this.Parent.Controls.Remove(this);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            //ScenesTab scenesTab = this.Parent.Parent as ScenesTab;
            //scenesTab.LoadSceneEditTab(_thisScene);
        }

        private void LoadData()
        {
            nameLabel.Text = _thisScene.Name;
            lastModificationLabel.Text += _thisScene.LastModificationDate.ToString("f", new CultureInfo("en-US"));
            if (_thisScene.Preview == null)
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
               // previewPanel.Controls.Add(new PPMViewer(_thisScene.Preview));
            }
        }
    }
}
