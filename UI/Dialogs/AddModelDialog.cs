using BusinessLogic;
using Controllers;
using Controllers.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class AddModelDialog : Form
    {
        public Model NewModel = new Model();
        private List<SphereDTO> _availableShapes;
        private List<Lambertian> _availableLambertians;
        private User _loggedUser;

        private SphereDTO _selectedShape;
        private Lambertian _selectedMaterial;
        private Context _context;
        private SphereController _sphereController;
        public AddModelDialog(User loggedUser, Context context)
        {
            InitializeComponent();
            _sphereController = context.SphereController;
            _loggedUser = loggedUser;
            _availableShapes = _sphereController.GetSpheresFromUser(loggedUser.UserName);
            _availableLambertians = LambertianRepository.GetLambertiansFromUser(loggedUser);

            LoadShapeComboBox();
            LoadMaterialComboBox();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string modelName = nameTextBox.Text;
            nameStatusLabel.Text = "";
            bool nameIsCorrect = true;

            try
            {
                NewModel.Name = modelName;
            }
            catch (ArgumentNullException)
            {
                nameStatusLabel.Text = "* Name cannot be empty";
                nameIsCorrect = false;
            }

            if (ModelRepository.ContainsModel(modelName, _loggedUser.UserName))
            {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Model with that name already exists";
            }

            if (nameIsCorrect)
            {
                NewModel.Owner = _loggedUser;
                NewModel.Shape = _sphereController.ConvertToSphere(_selectedShape);
                NewModel.Material = _selectedMaterial;
                DialogResult = DialogResult.OK;
            }

            if (previewCheckbox.Checked)
            {
                NewModel.RenderPreview();
            }
        }

        private void ShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedShape = _availableShapes[shapeComboBox.SelectedIndex];
        }

        private void MaterialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedMaterial = _availableLambertians[materialComboBox.SelectedIndex];
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoadShapeComboBox()
        {
            foreach (SphereDTO elem in _availableShapes)
            {
                shapeComboBox.Items.Add(elem.Name);
            }
        }

        private void LoadMaterialComboBox()
        {
            foreach (Lambertian elem in _availableLambertians)
            {
                materialComboBox.Items.Add(elem.Name);
            }
        }

    }
}
