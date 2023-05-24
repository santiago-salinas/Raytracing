using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;
using Controllers;

namespace UI.Tabs
{
    public partial class ScenesTab : Form
    {
        private string _currentUser;
        public EditSceneTab SceneEditDialog;
        private MainPage _mainPage;
        public ScenesTab(Context context, MainPage mainPage)
        {
            InitializeComponent();
            _loggedUser = context.CurrentUser;
            LoadScenes();
            _mainPage = mainPage;
        }

        public void LoadScenes()
        {
            flowLayoutPanel.Controls.Clear();
            //List<Scene> sceneList = SceneRepository.GetScenesFromUser(_loggedUser.UserName);
            //foreach (Scene elem in sceneList)
            //{
               // SceneCard sceneCard = new SceneCard(elem);
               // flowLayoutPanel.Controls.Add(sceneCard);
            //}
        }

        private void AddSceneButton_Click(object sender, EventArgs e)
        {
            LoadSceneEditTab(null);
        }

        public void LoadSceneEditTab(Scene scene)
        {
            /*if (SceneEditDialog == null)
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
            }*/
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
