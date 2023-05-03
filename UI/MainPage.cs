using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Collections;
using BusinessLogic.Objects;
using UI.Tabs;

namespace UI
{
    public partial class MainPage : Form
    {
        
        MaterialsTab materialsTab;
        ShapesTab shapesTab;
        ScenesTab scenesTab;
        ModelsTab modelsTab;
        User loggedUser;
        public MainPage(User providedUser)
        {
            InitializeComponent();
            loggedUser = providedUser;
            loggedUsernameLabel.Text = loggedUser.UserName;
        }

        private void scenesSideBarButton_Click(object sender, EventArgs e)
        {
            if(scenesTab == null)
            {
                scenesTab = new ScenesTab(loggedUser);
                scenesTab.FormClosed += scenesTabClosed;
                scenesTab.MdiParent = this;
                scenesTab.Dock = DockStyle.Fill;
                scenesTab.Show();
            }
            else
            {
                scenesTab.Activate();
            }
        }

        private void scenesTabClosed(object sender, FormClosedEventArgs e)
        {
            scenesTab = null;
        }

        private void modelsSideBarButton_Click(object sender, EventArgs e)
        {
            if (modelsTab == null)
            {
                modelsTab = new ModelsTab(loggedUser);
                modelsTab.FormClosed += modelsTabClosed;
                modelsTab.MdiParent = this;
                modelsTab.Dock = DockStyle.Fill;
                modelsTab.Show();
            }
            else
            {
                modelsTab.Activate();
            }
        }

        private void modelsTabClosed(object sender, FormClosedEventArgs e)
        {
            modelsTab = null;
        }

        private void materialsSideBarButton_Click(object sender, EventArgs e)
        {
            if (materialsTab == null)
            {
                materialsTab = new MaterialsTab(loggedUser);
                materialsTab.FormClosed += materialsTabClosed;
                materialsTab.MdiParent = this;
                materialsTab.Dock = DockStyle.Fill;
                materialsTab.Show();
            }
            else
            {
                materialsTab.Activate();
            }
        }

        private void materialsTabClosed(object sender, FormClosedEventArgs e)
        {
            materialsTab = null;
        }

        private void shapesSideBarButton_Click(object sender, EventArgs e)
        {
            if (shapesTab == null)
            {
                shapesTab = new ShapesTab(loggedUser);
                shapesTab.FormClosed += shapesTabClosed;
                shapesTab.MdiParent = this;
                shapesTab.Dock = DockStyle.Fill;
                shapesTab.Show();
            }
            else
            {
                shapesTab.Activate();
            }
        }

        private void shapesTabClosed(object sender, FormClosedEventArgs e)
        {
            shapesTab = null;
        }


        private void signOutButton_Click(object sender, EventArgs e)
        {
            new LogInPage().Show();
            this.Close();            
        }
    }
}
