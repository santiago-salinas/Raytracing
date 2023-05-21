using BusinessLogic;
using Controllers.Controllers;
using Controllers.DTOs;
using System;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class LambertianCard : UserControl
    {
        private LambertianDTO _lambertian;
        private LambertianController _controller;

        public LambertianCard(LambertianDTO lambertianDTO, LambertianController controller)
        {
            InitializeComponent();
            _lambertian = lambertianDTO;
            _controller = controller;
            nameLabel.Text = lambertianDTO.Name;

            ColorDTO color = lambertianDTO.Color;

            int redValue = (int)color.Red;
            int greenValue = (int)color.Green;
            int blueValue = (int)color.Blue;


            redValueLabel.Text += redValue.ToString();
            greenValueLabel.Text += greenValue.ToString();
            blueValueLabel.Text += blueValue.ToString();

            System.Drawing.Color shownColor = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
            colorPanel.BackColor = shownColor;

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RemoveLambertian(_lambertian.Name, _lambertian.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (BusinessLogicException)
            {
                deleteLabel.Visible = true;
            }
        }

    }
}
