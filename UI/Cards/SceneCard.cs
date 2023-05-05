using System;
using System.Windows.Forms;
using BusinessLogic;
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
            SceneCollection.RemoveScene(thisScene.Name, thisScene.Owner);
            this.Parent.Controls.Remove(this);
        }

        private void editButton_Click(object sender, EventArgs e)
        {

            /* SceneEditDialog newSceneDialog = new SceneEditDialog(thisScene,thisScene.Owner);            
             DialogResult result = newSceneDialog.ShowDialog();

             if (result == DialogResult.OK)
             {
                 loadData();
             }*/

            ScenesTab scenesTab = this.Parent.Parent as ScenesTab;
            scenesTab.loadSceneEditTab(thisScene);
        }

        private void loadData()
        {
            nameLabel.Text = thisScene.Name;
            //lastModificationLabel += thisScene.LastModificationDate.ToString();
            if(thisScene.Preview == null)
            {
                previewBox.Image = Properties.Resources.no_img_placeholder;
                previewBox.SizeMode = PictureBoxSizeMode.Zoom;
            }            
        }
    }
}
