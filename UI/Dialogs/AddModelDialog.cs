using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class AddModelDialog : Form
    {
        public Model NewModel = new Model();
        private List<Sphere> availableShapes;
        private List<Lambertian> availableLambertians;
        private User loggedUser;

        private Sphere selectedShape;
        private Lambertian selectedMaterial;
        public AddModelDialog(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.availableShapes = SphereCollection.GetSpheresFromUser(loggedUser);
            this.availableLambertians = LambertianCollection.GetLambertiansFromUser(loggedUser);

            loadShapeComboBox();
            shapeComboBox.SelectedIndex = 0;
            loadMaterialComboBox();
            materialComboBox.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string modelName = nameTextBox.Text;            
            nameStatusLabel.Text = "";            
            bool nameIsCorrect = true;
            
            try
            {
                NewModel.Name = modelName;
            }
            catch (ArgumentNullException ex)
            {
                nameStatusLabel.Text = "* Name cannot be empty";
                nameIsCorrect = false;
            }

            if (ModelCollection.ContainsModel(modelName, loggedUser))
            {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Model with that name already exists";
            }

            if (previewCheckbox.Checked)
            {
                //generate a ppm and grant it to model
                NewModel.Preview = new PPM(5, 5);
            }

            if (nameIsCorrect)
            {
                NewModel.Owner = loggedUser;
                NewModel.ModelShape = selectedShape;
                NewModel.ModelColor = selectedMaterial;
                DialogResult = DialogResult.OK;
            }
        }

        private void shapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShape = availableShapes[shapeComboBox.SelectedIndex];
        }

        private void materialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMaterial = availableLambertians[materialComboBox.SelectedIndex];
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void loadShapeComboBox()
        {
            foreach (Sphere elem in availableShapes)
            {
                shapeComboBox.Items.Add(elem.Name);
            }
        }

        private void loadMaterialComboBox()
        {
            foreach (Lambertian elem in availableLambertians)
            {
                materialComboBox.Items.Add(elem.Name);
            }
        }
    }
}
