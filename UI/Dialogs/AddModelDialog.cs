using Controllers;
using Controllers.Controllers;
using Controllers.Exceptions;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class AddModelDialog : Form
    {
        public ModelDTO NewModel;
        private List<SphereDTO> _availableShapes;
        private List<MaterialDTO> _availableMaterials;
        private string _loggedUser;

        private SphereDTO _selectedShape;
        private MaterialDTO _selectedMaterial;
        private ModelManagementController _controller;
        public AddModelDialog(Context context)
        {
            InitializeComponent();
            _loggedUser = context.CurrentUser;
            _controller = context.ModelController;
            
            _availableShapes = _controller.GetAvailableShapes(_loggedUser);
            _availableMaterials = _controller.GetAvailableMaterials(_loggedUser);

            LoadShapeComboBox();
            LoadMaterialComboBox();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string modelName = nameTextBox.Text;            
            nameStatusLabel.Text = "";
            bool nameIsCorrect = true;

            NewModel = new ModelDTO()
            {
                Name = modelName,
                OwnerName = _loggedUser,
                Shape = _selectedShape,
                Material = _selectedMaterial,
            };

            if (previewCheckbox.Checked)
            {
                NewModel.Preview = _controller.RenderPreview(NewModel);
            }
            else
            {
                NewModel.Preview = null;
            }

            try
            {
                _controller.AddModel(NewModel);
            }
            catch(Controller_ArgumentException ex)
            {
                nameStatusLabel.Text = ex.Message;
                nameIsCorrect = false;
            }

            if (nameIsCorrect)
            {
                DialogResult = DialogResult.OK;
            }

            
        }

        private void ShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedShape = _availableShapes[shapeComboBox.SelectedIndex];
        }

        private void MaterialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedMaterial = _availableMaterials[materialComboBox.SelectedIndex];
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
            foreach (MaterialDTO elem in _availableMaterials)
            {
                materialComboBox.Items.Add(elem.Name);
            }
        }

    }
}
