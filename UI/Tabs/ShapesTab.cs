using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogic;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class ShapesTab : Form
    {
        public ShapesTab()
        {
            InitializeComponent();
            loadSpheres();
        }

        private void addShapeButton_Click(object sender, EventArgs e)
        {
            AddSphere addSphere = new AddSphere();
            DialogResult result = addSphere.ShowDialog();

            if (result == DialogResult.OK) {
                SphereCard sphereCard = new SphereCard(addSphere.NewSphere);
                SphereCollection.AddSphere(addSphere.NewSphere);
                flowLayoutPanel.Controls.Add(sphereCard);
            }
        }

        private void loadSpheres()
        {
            List<Sphere> sphereList = SphereCollection.SphereList;
            foreach (Sphere elem in sphereList)
            {
                SphereCard sphereCard = new SphereCard(elem);
                flowLayoutPanel.Controls.Add(sphereCard);
            }
        }
    }
}
