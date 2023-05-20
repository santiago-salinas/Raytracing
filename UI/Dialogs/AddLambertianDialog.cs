using BusinessLogic;
using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class AddLambertianDialog : Form
    {
        private const int _maximumRGBValue = 255;
        private Color _color;

        public Lambertian NewLambertian = new Lambertian();
        private User _loggedUser { get; set; }
        public AddLambertianDialog(User loggedUser)
        {
            InitializeComponent();
            this._loggedUser = loggedUser;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string lambertianName = nameTextBox.Text;

            nameStatusLabel.Text = "";
            colorStatusLabel.Visible = false;

            bool nameIsCorrect = true;
            bool colorValuesAreCorrect = true;

            try
            {
                NewLambertian.Name = lambertianName;
            }
            catch (ArgumentNullException)
            {
                nameStatusLabel.Text = "* Name cannot be empty";
                nameIsCorrect = false;
            }

            if (LambertianRepository.ContainsLambertian(lambertianName, _loggedUser))
            {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Material with that name already exists";
            }

            double redValue = (double)redValueInput.Value / _maximumRGBValue;
            double greenValue = (double)greenValueInput.Value / _maximumRGBValue;
            double blueValue = (double)blueValueInput.Value / _maximumRGBValue;
            try
            {
                _color = new BusinessLogic.Color(redValue, greenValue, blueValue);
                NewLambertian.Color = _color;
            }
            catch (ArgumentException)
            {
                colorStatusLabel.Visible = true;
                colorValuesAreCorrect = false;
            }

            if (nameIsCorrect && colorValuesAreCorrect)
            {
                NewLambertian.Owner = _loggedUser;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
