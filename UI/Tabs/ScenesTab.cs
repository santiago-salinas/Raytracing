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
using BusinessLogic;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class ScenesTab : Form
    {
        private User loggedUser;
        public Button newSceneButton;
        public ScenesTab(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            loadScenes();
            newSceneButton = addSceneButton;
           
        }

        private void loadScenes()
        {
            List<Scene> sceneList = SceneCollection.GetScenesFromUser(loggedUser);
            foreach (Scene elem in sceneList)
            {
                SceneCard sceneCard = new SceneCard(elem);
                flowLayoutPanel.Controls.Add(sceneCard);
            }
        }

        private void addSceneButton_Click(object sender, EventArgs e)
        {
            Scene newScene = new Scene()
            {
                Name = "Blank scene",
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,    
            };
            
            SceneEditDialog newSceneDialog = new SceneEditDialog(newScene,loggedUser);            
            DialogResult result = newSceneDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                SceneCard newSceneCard = new SceneCard(newScene);
                SceneCollection.AddScene(newScene);
                flowLayoutPanel.Controls.Add(newSceneCard);
            }

        }


    }
}
