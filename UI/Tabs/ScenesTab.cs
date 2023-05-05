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
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class ScenesTab : Form
    {
        private User loggedUser;
        //public Button newSceneButton;
        public SceneEditDialog sceneEditDialog;
        private MainPage mainPage;
        public ScenesTab(User loggedUser,MainPage mainPage)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            loadScenes();
            //newSceneButton = addSceneButton;
            this.mainPage = mainPage;
        }

        public void loadScenes()
        {
            flowLayoutPanel.Controls.Clear();
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
                Owner = loggedUser
            };

            //SceneEditDialog newSceneDialog = new SceneEditDialog(newScene,loggedUser);            
            // DialogResult result = newSceneDialog.ShowDialog();

            /* if (result == DialogResult.OK)
             {
                 SceneCard newSceneCard = new SceneCard(newScene);
                 SceneCollection.AddScene(newScene);
                 flowLayoutPanel.Controls.Add(newSceneCard);
             }*/

            loadSceneEditTab(null);
        }

        public void loadSceneEditTab(Scene scene)
        {
            if (sceneEditDialog == null)
            {
                SceneEditDialog sceneEditDialog = new SceneEditDialog(scene, loggedUser);
                sceneEditDialog.scenesTab = this;
                sceneEditDialog.FormClosed += editSceneClosed;
                sceneEditDialog.MdiParent = mainPage;
                sceneEditDialog.Dock = DockStyle.Fill;
                sceneEditDialog.Show();
            }
            else
            {
                sceneEditDialog.loadDataFromScene(scene);
                sceneEditDialog.Activate();
            }
        }

        public void editSceneClosed(object sender, EventArgs e)
        {
            sceneEditDialog = null;
        }

    }
}
