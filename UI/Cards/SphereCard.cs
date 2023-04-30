using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Objects;
using BusinessLogic.Collections;

namespace UI.Cards
{
    public partial class SphereCard : UserControl
    {
        public SphereCard()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SphereCollection.RemoveSphere(sphere.Name);
                this.Parent.Controls.Remove(this);
            }catch (BusinessLogicException ex)
            {
                deleteLabel.Visible = true;
            }      
        }
        
        private Sphere sphere;

        public SphereCard(Sphere sphere)
        {
            InitializeComponent();
            this.sphere = sphere;
            nameLabel.Text = sphere.Name;           
            radiusLabel.Text = "Radius: " + sphere.Radius.ToString();

        }

    }
}
