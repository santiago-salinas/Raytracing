using BusinessLogic;
using System;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class MaterialCard : UserControl
    {
        private Material _material;

        public MaterialCard(Material material)
        {
            InitializeComponent();
            this._material = material;
            nameLabel.Text = material.Name;

            BusinessLogic.Color color = material.Preview;

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
                Materials.RemoveMaterial(_material.Name, _material.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (BusinessLogicException)
            {
                deleteLabel.Visible = true;
            }
        }

    }
}
