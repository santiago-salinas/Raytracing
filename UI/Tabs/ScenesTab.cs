using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;

namespace UI.Tabs
{
    public partial class ScenesTab : Form
    {
        private User loggedUser;
        public EditSceneTab sceneEditDialog;
        private MainPage mainPage;
        public ScenesTab(User loggedUser, MainPage mainPage)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            loadScenes();
            this.mainPage = mainPage;
        }

        public void loadScenes()
        {
            flowLayoutPanel.Controls.Clear();
            List<Scene> sceneList = Scenes.GetScenesFromUser(loggedUser);
            foreach (Scene elem in sceneList)
            {
                SceneCard sceneCard = new SceneCard(elem);
                flowLayoutPanel.Controls.Add(sceneCard);
            }
        }

        private void addSceneButton_Click(object sender, EventArgs e)
        {
            loadSceneEditTab(null);
        }

        public void loadSceneEditTab(Scene scene)
        {
            if (sceneEditDialog == null)
            {
                EditSceneTab sceneEditDialog = new EditSceneTab(scene, loggedUser);
                sceneEditDialog.scenesTab = this;
                sceneEditDialog.FormClosed += editSceneClosed;
                sceneEditDialog.MdiParent = mainPage;
                sceneEditDialog.Dock = DockStyle.Fill;
                sceneEditDialog.Show();
            }
            else
            {               
                sceneEditDialog.Activate();
            }
        }

        public void editSceneClosed(object sender, EventArgs e)
        {
            sceneEditDialog = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadSceneEditTab(null);
        }
    }
}
