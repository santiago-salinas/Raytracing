using Controllers;
using Controllers.Exceptions;
using DataTransferObjects;
using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class AddSphereDialog : Form
    {

        private string _currentUser;
        public SphereDTO NewSphereDTO { get; set; }
        private SphereManagementController _sphereController;
        public AddSphereDialog(string currentUser, SphereManagementController sphereController)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _sphereController = sphereController;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string sphereName = nameTextBox.Text;
            float radius = (float)radiusInput.Value;
            NewSphereDTO = new SphereDTO(sphereName, radius, _currentUser);
            statusLabel.Text = "";
            bool inputsAreCorrect = true;

            try
            {
                _sphereController.AddSphere(NewSphereDTO);
            }
            catch (Controller_ObjectHandlingException ex)
            {
                statusLabel.Text = ex.Message;
                inputsAreCorrect = false;
            }

            if (inputsAreCorrect)
            {
                DialogResult = DialogResult.OK;
            }

        }
    }
}
