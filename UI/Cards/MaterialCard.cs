using BusinessLogic;
using Controllers;
using DataTransferObjects;
using System;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class MaterialCard : UserControl
    {
        private MaterialDTO _lambertian;
        private MaterialManagementController _controller;

        public MaterialCard(MaterialDTO lambertianDTO, MaterialManagementController controller)
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
                _controller.RemoveMaterial(_lambertian.Name, _lambertian.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (Exception)
            {
                deleteLabel.Visible = true;
            }
        }

    }
}
