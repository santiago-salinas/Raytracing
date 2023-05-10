using BusinessLogic;
using System;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class SphereCard : UserControl
    {

        private Sphere _sphere;
        public SphereCard()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Spheres.RemoveSphere(_sphere.Name, _sphere.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (BusinessLogicException)
            {
                deleteLabel.Visible = true;
            }
        }


        public SphereCard(Sphere sphere)
        {
            InitializeComponent();
            this._sphere = sphere;
            nameLabel.Text = sphere.Name;
            radiusLabel.Text = "Radius: " + sphere.Radius.ToString();

        }

    }
}
