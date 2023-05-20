using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;

namespace UI.Tabs
{
    public partial class ScenesTab : Form
    {
        private User _loggedUser;
        public EditSceneTab SceneEditDialog;
        private MainPage _mainPage;
        public ScenesTab(User loggedUser, MainPage mainPage)
        {
            InitializeComponent();
            this._loggedUser = loggedUser;
            LoadScenes();
            this._mainPage = mainPage;
        }

        public void LoadScenes()
        {
            flowLayoutPanel.Controls.Clear();
            List<Scene> sceneList = SceneRepository.GetScenesFromUser(_loggedUser);
            foreach (Scene elem in sceneList)
            {
                SceneCard sceneCard = new SceneCard(elem);
                flowLayoutPanel.Controls.Add(sceneCard);
            }
        }

        private void AddSceneButton_Click(object sender, EventArgs e)
        {
            LoadSceneEditTab(null);
        }

        public void LoadSceneEditTab(Scene scene)
        {
            if (SceneEditDialog == null)
            {
                EditSceneTab sceneEditDialog = new EditSceneTab(scene, _loggedUser);
                sceneEditDialog.ScenesTab = this;
                sceneEditDialog.FormClosed += EditSceneClosed;
                sceneEditDialog.MdiParent = _mainPage;
                sceneEditDialog.Dock = DockStyle.Fill;
                sceneEditDialog.Show();
            }
            else
            {
                SceneEditDialog.Activate();
            }
        }

        public void EditSceneClosed(object sender, EventArgs e)
        {
            SceneEditDialog = null;
        }

        private void PlusSymbolImage_Click(object sender, EventArgs e)
        {
            LoadSceneEditTab(null);
        }
    }
}
