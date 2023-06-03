using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;
using Controllers;
using Controllers.Controllers;
using DataTransferObjects;

namespace UI.Tabs
{
    public partial class MaterialsTab : Form
    {
        private string _loggedUser;
        private Context _context;
        private MaterialManagementController _materialController;
        public MaterialsTab(Context context)
        {
            InitializeComponent();
            _context = context;
            _loggedUser = context.CurrentUser;
            _materialController = context.MaterialController;
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            List<MaterialDTO> materialList = _materialController.GetMaterialsFromUser(_loggedUser);
            foreach (MaterialDTO elem in materialList)
            {
                MaterialCard materialCard = new MaterialCard(elem,_materialController);
                flowLayoutPanel.Controls.Add(materialCard);
            }
        }

        private void AddMaterialButton_Click(object sender, EventArgs e)
        {
            AddMaterialDialog addMaterial = new AddMaterialDialog(_context);
            DialogResult result = addMaterial.ShowDialog();

            if (result == DialogResult.OK)
            {
                MaterialCard materialCard = new MaterialCard(addMaterial.NewMaterial, _materialController);
                flowLayoutPanel.Controls.Add(materialCard);
            }
        }
    }
}
