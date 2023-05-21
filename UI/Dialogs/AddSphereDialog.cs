using BusinessLogic;
using System;
using System.Windows.Forms;
using Controllers;
using Controllers.DTOs;

namespace UI.Dialogs
{
    public partial class AddSphereDialog : Form
    {
       
        private string _currentUser;
        public SphereDTO NewSphereDTO { get; set; }
        private SphereController _sphereController;
        public AddSphereDialog(string currentUser, SphereController sphereController)
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

            statusLabel.Text = "";           

            bool nameIsCorrect = true;
            bool radiusIsCorrect = true;

            string status = _sphereController.CheckNameValidity(sphereName, _currentUser);

            if(status != "OK")
            {
                statusLabel.Text = status;
                nameIsCorrect = false;
            }
            status = _sphereController.CheckRadiusValidity(radius);
            if(status != "OK")
            {
                statusLabel.Text = status;
                radiusIsCorrect = false;
            }

            if (nameIsCorrect && radiusIsCorrect)
            {
                NewSphereDTO = new SphereDTO(sphereName, radius, _currentUser);
                DialogResult = DialogResult.OK;
            }

        }
    }
}
