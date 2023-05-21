using BusinessLogic;
using Controllers;
using Controllers.Controllers;
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
        private List<LambertianDTO> _availableLambertians;
        private string _loggedUser;

        private SphereDTO _selectedShape;
        private LambertianDTO _selectedMaterial;
        private SphereController _sphereController;
        private LambertianController _lambertianController;
        public AddModelDialog(Context context)
        {
            InitializeComponent();
            _sphereController = context.SphereController;
            _lambertianController = context.LambertianController;
            _loggedUser = context.CurrentUser;
            
            _availableShapes = _sphereController.GetSpheresFromUser(_loggedUser);
            _availableLambertians = _lambertianController.GetLambertiansFromUser(_loggedUser);

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

            if (ModelRepository.ContainsModel(modelName, _loggedUser))
            {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Model with that name already exists";
            }

            if (nameIsCorrect)
            {
                NewModel.Owner = _loggedUser;
                NewModel.Shape = _sphereController.ConvertToSphere(_selectedShape);
                NewModel.Material = _lambertianController.ConvertToLambertian(_selectedMaterial);
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
            foreach (LambertianDTO elem in _availableLambertians)
            {
                materialComboBox.Items.Add(elem.Name);
            }
        }

    }
}
