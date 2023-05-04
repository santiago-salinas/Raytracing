using System;
using System.Windows.Forms;
using BusinessLogic;

namespace UI.Dialogs
{
    public partial class AddLambertianDialog : Form
    {
   
        private Color color;

        public Lambertian NewLambertian = new Lambertian();
        private User loggedUser {  get; set; }
        public AddLambertianDialog(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string lambertianName = nameTextBox.Text;
            
            nameStatusLabel.Text = "";
            colorStatusLabel.Visible = false;
            
            bool nameIsCorrect = true;
            bool colorValuesAreCorrect = true;
            
            try
            {
                NewLambertian.Name = lambertianName;
            }catch (ArgumentNullException ex)
            {
                nameStatusLabel.Text = "* Name cannot be empty";
                nameIsCorrect = false;
            }

            if (LambertianCollection.ContainsLambertian(lambertianName,loggedUser)) {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Material with that name already exists";
            }

            double redValue = (double)redValueInput.Value / 255;
            double greenValue = (double)greenValueInput.Value / 255;
            double blueValue = (double)blueValueInput.Value / 255;           
            try
            {
                color = new BusinessLogic.Color(redValue,greenValue,blueValue);
                NewLambertian.Color = color;
            }catch(ArgumentException ex)
            {
                colorStatusLabel.Visible = true;
                colorValuesAreCorrect = false;
            }

            if(nameIsCorrect && colorValuesAreCorrect) {
                NewLambertian.Owner = loggedUser;
                DialogResult = DialogResult.OK;
            }
    
            
            
        }
    }
}
