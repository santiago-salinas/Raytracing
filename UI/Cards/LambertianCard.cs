using BusinessLogic;
using System;
using System.Windows.Forms;

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

            int redValue = (int)color.Red;
            int greenValue = (int)color.Green;
            int blueValue = (int)color.Blue;


            redValueLabel.Text += redValue.ToString();
            greenValueLabel.Text += greenValue.ToString();
            blueValueLabel.Text += blueValue.ToString();

            System.Drawing.Color shownColor = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
            colorPanel.BackColor = shownColor;

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Lambertians.RemoveLambertian(lambertian.Name, lambertian.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (BusinessLogicException)
            {
                deleteLabel.Visible = true;
            }
        }

    }
}
