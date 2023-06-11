using BusinessLogic;
using System;
using System.Windows.Forms;
using Controllers;
using DataTransferObjects;

namespace UI.Dialogs
{
    public partial class AddMaterialDialog : Form
    {
        private MaterialManagementController _controller;
        private string _loggedUser;

        public MaterialDTO NewMaterial;
        public AddMaterialDialog(Context context)
        {
            InitializeComponent();
            _controller = context.MaterialController;
            _loggedUser = context.CurrentUser;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string materialName = nameTextBox.Text;
            int redValue = (int)redValueInput.Value;
            int greenValue = (int)greenValueInput.Value;
            int blueValue = (int)blueValueInput.Value;
            double roughnessValue = (double) roughnessInput.Value;

            statusLabel.Text = "";

            bool inputsAreCorrect = true;
            ColorDTO colorDTO = new ColorDTO()
            {
                Red = redValue,
                Green = greenValue,
                Blue = blueValue,
            };
            NewMaterial = new MaterialDTO()
            {
                Name = materialName,
                Color = colorDTO,
                Owner = _loggedUser,
                Type = metallicCheck.Checked ? "metallic" : "lambertian",
                Roughness=roughnessValue,
            };

            try
            {
                _controller.AddMaterial(NewMaterial);
            }catch (Exception ex)
            {
                statusLabel.Text = ex.Message;
                inputsAreCorrect = false;
            }

            if (inputsAreCorrect)
            {                
                DialogResult = DialogResult.OK;
            }
        }

        private void metallicCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (metallicCheck.Checked)
            {
                roughnessInput.Enabled = true;
            }
            else
            {
                roughnessInput.Enabled = false;
            }
        }
    }
}
