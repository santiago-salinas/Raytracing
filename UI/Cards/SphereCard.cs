using BusinessLogic;
using System;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class SphereCard : UserControl
    {

        private Sphere sphere;
        public SphereCard()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Spheres.RemoveSphere(sphere.Name, sphere.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (BusinessLogicException ex)
            {
                deleteLabel.Visible = true;
            }
        }


        public SphereCard(Sphere sphere)
        {
            InitializeComponent();
            this.sphere = sphere;
            nameLabel.Text = sphere.Name;
            radiusLabel.Text = "Radius: " + sphere.Radius.ToString();

        }

    }
}
