using BusinessLogic;
using Controllers;
using Controllers.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class ShapesTab : Form
    {

        private string _currentUser;
        private SphereManagementController _sphereController;
        public ShapesTab(Context context)
        {
            InitializeComponent();
            _currentUser = context.CurrentUser;
            _sphereController = context.SphereController;
            LoadSpheres();
        }

        private void AddShapeButton_Click(object sender, EventArgs e)
        {
            AddSphereDialog addSphere = new AddSphereDialog(_currentUser,_sphereController);
            DialogResult result = addSphere.ShowDialog();

            if (result == DialogResult.OK)
            {
                SphereCard sphereCard = new SphereCard(addSphere.NewSphereDTO,_sphereController);              
                flowLayoutPanel.Controls.Add(sphereCard);
            }
        }

        private void LoadSpheres()
        {
            List<SphereDTO> sphereList = _sphereController.GetSpheresFromUser(_currentUser);
            foreach (SphereDTO elem in sphereList)
            {
                SphereCard sphereCard = new SphereCard(elem,_sphereController);
                flowLayoutPanel.Controls.Add(sphereCard);
            }
        }

    }
}
