using Controllers;
using Controllers.Exceptions;
using DataTransferObjects;
using System;
using System.Windows.Forms;

namespace UI.Cards
{
    public partial class MaterialCard : UserControl
    {
        private MaterialDTO _material;
        private MaterialManagementController _controller;

        public MaterialCard(MaterialDTO materialDTO, MaterialManagementController controller)
        {
            InitializeComponent();
            _material = materialDTO;
            _controller = controller;
            nameLabel.Text = materialDTO.Name;

            ColorDTO color = materialDTO.Color;

            int redValue = (int)color.Red;
            int greenValue = (int)color.Green;
            int blueValue = (int)color.Blue;

            infoLabel.Text = materialDTO.Info;

            System.Drawing.Color shownColor = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
            colorPanel.BackColor = shownColor;

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RemoveMaterial(_material.Name, _material.Owner);
                this.Parent.Controls.Remove(this);
            }
            catch (Controller_ObjectHandlingException)
            {
                deleteLabel.Visible = true;
            }
        }

    }
}
