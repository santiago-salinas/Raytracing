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
using BusinessLogic.Objects;
using BusinessLogic.Collections;
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
            
            SceneEditDialog newSceneDialog = new SceneEditDialog(thisScene,thisScene.Owner);            
            DialogResult result = newSceneDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                loadData();
            }
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
