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
        private const int _maximumRGBValue = 255;
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
            this.DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string lambertianName = nameTextBox.Text;
            double redValue = (double)redValueInput.Value / _maximumRGBValue;
            double greenValue = (double)greenValueInput.Value / _maximumRGBValue;
            double blueValue = (double)blueValueInput.Value / _maximumRGBValue;

            nameStatusLabel.Text = "";

            bool nameIsCorrect = true;
            bool colorValuesAreCorrect = true;
            ColorDTO colorDTO = new ColorDTO()
            {
                Red = redValue,
                Green = greenValue,
                Blue = blueValue,
            };
            LambertianDTO lambertianDTO = new LambertianDTO()
            {
                Name = lambertianName,
                Color = colorDTO,
                Owner = _loggedUser,
            };

            try
            {
                _controller.AddLambertian(lambertianDTO);
            }catch (Exception ex)
            {
                statusLabel.Text = ex.Message;
                nameIsCorrect = false;
            }

            /*try
            {
                NewLambertian.Name = lambertianName;
            }
            catch (ArgumentNullException)
            {
                nameStatusLabel.Text = "* Name cannot be empty";
                nameIsCorrect = false;
            }

            if (_controller.ContainsLambertian(lambertianName, _loggedUser))
            {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Material with that name already exists";
            }

            
            try
            {
                _color = new BusinessLogic.Color(redValue, greenValue, blueValue);
                NewLambertian.Color = _color;
            }
            catch (ArgumentException)
            {
                statusLabel.Visible = true;
                colorValuesAreCorrect = false;
            }*/

            if (nameIsCorrect && colorValuesAreCorrect)
            {
                NewLambertian = lambertianDTO;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
