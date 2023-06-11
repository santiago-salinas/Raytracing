using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;
using Controllers;
using DataTransferObjects;

namespace UI.Tabs
{
    public partial class ScenesTab : Form
    {
        private string _currentUser;
        public EditSceneTab SceneEditDialog;
        private MainPage _mainPage;
        private SceneManagementController _controller;
        private Context _context;
        public ScenesTab(Context context, MainPage mainPage)
        {
            InitializeComponent();
            _context = context;
            _mainPage = mainPage;
            _controller = context.SceneController;
            _currentUser = context.CurrentUser;
            LoadScenes();    
        }

        public void LoadScenes()
        {
            flowLayoutPanel.Controls.Clear();
            List<SceneDTO> sceneList = _controller.GetScenesFromUser(_currentUser);
            foreach (SceneDTO elem in sceneList)
            {
               SceneCard sceneCard = new SceneCard(_controller,elem);
               flowLayoutPanel.Controls.Add(sceneCard);
            }
        }

        private void AddSceneButton_Click(object sender, EventArgs e)
        {
            LoadSceneEditTab(null);
        }

        public void LoadSceneEditTab(SceneDTO scene)
        {
            if (SceneEditDialog == null)
            {
                EditSceneTab sceneEditDialog = new EditSceneTab(scene, _context);
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
