using Controllers;
using Controllers.Exceptions;
using System;
using System.Windows.Forms;
using DataTransferObjects;

namespace UI.Cards
{
    public partial class SphereCard : UserControl
    {

        private SphereDTO _sphereDTO;
        private SphereManagementController _controller;

        public SphereCard(SphereDTO sphereDTO, SphereManagementController controller)
        {
            InitializeComponent();
            _sphereDTO = sphereDTO;
            nameLabel.Text = _sphereDTO.Name;
            radiusLabel.Text = "Radius: " + _sphereDTO.Radius.ToString();
            _controller = controller;
        }     

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RemoveSphere(_sphereDTO.Name, _sphereDTO.OwnerName);
                Parent.Controls.Remove(this);
            }
            catch (Controller_ObjectHandlingException)
            {
                deleteLabel.Visible = true;
            }
        }
    }
}
