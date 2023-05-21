using BusinessLogic;
using System;
using System.Windows.Forms;
using Controllers;
using Controllers.Controllers;
using Controllers.DTOs;

namespace UI.Dialogs
{
    public partial class AddLambertianDialog : Form
    {
        private LambertianController _controller;
        private string _loggedUser;

        public LambertianDTO NewLambertian;
        public AddLambertianDialog(Context context)
        {
            InitializeComponent();
            _controller = context.LambertianController;
            _loggedUser = context.CurrentUser;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string lambertianName = nameTextBox.Text;
            int redValue = (int)redValueInput.Value;
            int greenValue = (int)greenValueInput.Value;
            int blueValue = (int)blueValueInput.Value;

            statusLabel.Text = "";

            bool inputsAreCorrect = true;
            ColorDTO colorDTO = new ColorDTO()
            {
                Red = redValue,
                Green = greenValue,
                Blue = blueValue,
            };
            NewLambertian = new LambertianDTO()
            {
                Name = lambertianName,
                Color = colorDTO,
                Owner = _loggedUser,
            };

            try
            {
                _controller.AddLambertian(NewLambertian);
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
    }
}
