using Controllers;
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

        private bool _isSignignOut = false;
        private Context _context;
        public MainPage(Context context)
        {
            InitializeComponent();
            loggedUsernameLabel.Text = context.CurrentUser;
            _context = context;
        }

        private void ScenesSideBarButton_Click(object sender, EventArgs e)
        {
            if (_scenesTab == null)
            {
                _scenesTab = new ScenesTab(_context, this);
                _scenesTab.FormClosed += ScenesTabClosed;
                _scenesTab.MdiParent = this;
                _scenesTab.Dock = DockStyle.Fill;
                _scenesTab.Show();
            }
            else
            {
                _scenesTab.LoadScenes();
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
                _modelsTab = new ModelsTab(_context);
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
                _materialsTab = new MaterialsTab(_context);
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
                _shapesTab = new ShapesTab(_context);
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
                new LogInPage(_context).Show();
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
