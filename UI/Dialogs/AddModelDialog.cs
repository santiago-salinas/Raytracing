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
        public ModelDTO NewModel;
        private List<SphereDTO> _availableShapes;
        private List<LambertianDTO> _availableLambertians;
        private string _loggedUser;

        private SphereDTO _selectedShape;
        private LambertianDTO _selectedMaterial;
        private ModelManagementController _controller;
        public AddModelDialog(Context context)
        {
            InitializeComponent();
            _loggedUser = context.CurrentUser;
            _controller = context.ModelController;
            
            _availableShapes = _controller.GetAvailableShapes(_loggedUser);
            _availableLambertians = _controller.GetAvailableMaterials(_loggedUser);

            LoadShapeComboBox();
            LoadMaterialComboBox();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string modelName = nameTextBox.Text;            
            nameStatusLabel.Text = "";
            bool nameIsCorrect = true;

            NewModel = new ModelDTO();
            NewModel.Name = modelName;
            NewModel.OwnerName = _loggedUser;
            NewModel.Shape = _selectedShape;
            NewModel.Material = _selectedMaterial;             

            try
            {
                _controller.AddModel(NewModel);
            }
            catch(Exception ex)
            {
                nameStatusLabel.Text = ex.Message;
            }


            /*try
            {
                NewModel.Name = modelName;
            }
            catch (ArgumentNullException)
            {
                nameStatusLabel.Text = "* Name cannot be empty";
                nameIsCorrect = false;
            }

            if (.ContainsModel(modelName, _loggedUser))
            {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Model with that name already exists";
            }*/

            if (nameIsCorrect)
            {
                DialogResult = DialogResult.OK;
            }

            if (previewCheckbox.Checked)
            {
                //NewModel.RenderPreview();
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
