using BusinessLogic;
using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class AddSphereDialog : Form
    {

        public Sphere NewSphere = new Sphere();
        private User _loggedUser { get; set; }
        public AddSphereDialog(User loggedUser)
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
            string sphereName = nameTextBox.Text;
            float radius = (float)radiusInput.Value;
            nameStatusLabel.Text = "";
            radiusStatusLabel.Visible = false;

            bool nameIsCorrect = true;
            bool radiusIsCorrect = true;

            try
            {
                NewSphere.Name = sphereName;
            }
            catch (ArgumentNullException)
            {
                nameStatusLabel.Text = "* Name cannot be empty";
                nameIsCorrect = false;
            }

            if (Spheres.ContainsSphere(sphereName, _loggedUser))
            {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Sphere with that name already exists";
            }

            try
            {
                NewSphere.Radius = radius;
            }
            catch (BusinessLogicException)
            {
                radiusStatusLabel.Visible = true;
                radiusIsCorrect = false;
            }

            if (nameIsCorrect && radiusIsCorrect)
            {
                NewSphere.Owner = _loggedUser;
                DialogResult = DialogResult.OK;
            }

        }
    }
}
