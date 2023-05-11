﻿using BusinessLogic;
using System;
using System.Windows.Forms;
using UI.Tabs;

namespace UI
{
    public partial class MainPage : Form
    {

        private MaterialsTab _materialsTab;
        private ShapesTab _shapesTab;
        private ScenesTab _scenesTab;
        private ModelsTab _modelsTab;
        private User _loggedUser;
        private bool _isSignignOut = false;
        public MainPage(User providedUser)
        {
            InitializeComponent();
            _loggedUser = providedUser;
            loggedUsernameLabel.Text = _loggedUser.UserName;
        }

        private void ScenesSideBarButton_Click(object sender, EventArgs e)
        {
            if (_scenesTab == null)
            {
                _scenesTab = new ScenesTab(_loggedUser, this);
                _scenesTab.FormClosed += ScenesTabClosed;
                _scenesTab.MdiParent = this;
                _scenesTab.Dock = DockStyle.Fill;
                _scenesTab.Show();
            }
            else
            {
                _scenesTab.Activate();
            }
            _scenesTab.LoadScenes();
        }

        private void ScenesTabClosed(object sender, FormClosedEventArgs e)
        {
            _scenesTab = null;
        }

        private void ModelsSideBarButton_Click(object sender, EventArgs e)
        {
            if (_modelsTab == null)
            {
                _modelsTab = new ModelsTab(_loggedUser);
                _modelsTab.FormClosed += ModelsTabClosed;
                _modelsTab.MdiParent = this;
                _modelsTab.Dock = DockStyle.Fill;
                _modelsTab.Show();
            }
            else
            {
                _modelsTab.Activate();
            }
        }

        private void ModelsTabClosed(object sender, FormClosedEventArgs e)
        {
            _modelsTab = null;
        }

        private void MaterialsSideBarButton_Click(object sender, EventArgs e)
        {
            if (_materialsTab == null)
            {
                _materialsTab = new MaterialsTab(_loggedUser);
                _materialsTab.FormClosed += MaterialsTabClosed;
                _materialsTab.MdiParent = this;
                _materialsTab.Dock = DockStyle.Fill;
                _materialsTab.Show();
            }
            else
            {
                _materialsTab.Activate();
            }
        }

        private void MaterialsTabClosed(object sender, FormClosedEventArgs e)
        {
            _materialsTab = null;
        }

        private void ShapesSideBarButton_Click(object sender, EventArgs e)
        {
            if (_shapesTab == null)
            {
                _shapesTab = new ShapesTab(_loggedUser);
                _shapesTab.FormClosed += ShapesTabClosed;
                _shapesTab.MdiParent = this;
                _shapesTab.Dock = DockStyle.Fill;
                _shapesTab.Show();
            }
            else
            {
                _shapesTab.Activate();
            }
        }

        private void ShapesTabClosed(object sender, FormClosedEventArgs e)
        {
            _shapesTab = null;
        }

        

        private void SignOutButton_Click(object sender, EventArgs e)
        {
            _isSignignOut = true;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isSignignOut)
            {
                _isSignignOut = false;
                new LogInPage().Show();
                base.OnFormClosing(e);
            }
            else
            {
                Application.Exit();
                base.OnFormClosing(e);
            }

        }
    }
}
