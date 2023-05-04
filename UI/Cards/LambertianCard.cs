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
using BusinessLogic.Utilities;

namespace UI.Cards
{
    public partial class LambertianCard : UserControl
    {
        private Lambertian lambertian;

        public LambertianCard(Lambertian lambertian)
        {
            InitializeComponent();
            this.lambertian = lambertian;
            nameLabel.Text = lambertian.Name;
            
            BusinessLogic.Color color = lambertian.Color;


            redValueLabel.Text += color.Red.ToString();
            blueValueLabel.Text += color.Blue.ToString();
            greenValueLabel.Text += color.Green.ToString();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                LambertianCollection.RemoveLambertian(lambertian.Name, lambertian.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (BusinessLogicException ex)
            {
                deleteLabel.Visible = true;
            }
        }
    }
}
