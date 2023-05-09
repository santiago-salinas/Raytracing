using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class ShapesTab : Form
    {

        private User loggedUser;
        public ShapesTab(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            loadSpheres();

        }

        private void addShapeButton_Click(object sender, EventArgs e)
        {
            AddSphereDialog addSphere = new AddSphereDialog(loggedUser);
            DialogResult result = addSphere.ShowDialog();

            if (result == DialogResult.OK)
            {
                SphereCard sphereCard = new SphereCard(addSphere.NewSphere);
                Spheres.AddSphere(addSphere.NewSphere);
                flowLayoutPanel.Controls.Add(sphereCard);
            }
        }

        private void loadSpheres()
        {
            List<Sphere> sphereList = Spheres.GetSpheresFromUser(loggedUser);
            foreach (Sphere elem in sphereList)
            {
                SphereCard sphereCard = new SphereCard(elem);
                flowLayoutPanel.Controls.Add(sphereCard);
            }
        }

    }
}
