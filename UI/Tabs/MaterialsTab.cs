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
        private MaterialManagementController _lambertianController;
        public MaterialsTab(Context context)
        {
            InitializeComponent();
            _context = context;
            _loggedUser = context.CurrentUser;
            _lambertianController = context.LambertianController;
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            List<MaterialDTO> lambertianList = _lambertianController.GetLambertiansFromUser(_loggedUser);
            foreach (MaterialDTO elem in lambertianList)
            {
                LambertianCard lambertianCard = new LambertianCard(elem,_lambertianController);
                flowLayoutPanel.Controls.Add(lambertianCard);
            }
        }

        private void AddMaterialButton_Click(object sender, EventArgs e)
        {
            AddLambertianDialog addMaterial = new AddLambertianDialog(_context);
            DialogResult result = addMaterial.ShowDialog();

            if (result == DialogResult.OK)
            {
                LambertianCard materialCard = new LambertianCard(addMaterial.NewLambertian, _lambertianController);
                flowLayoutPanel.Controls.Add(materialCard);
            }
        }
    }
}
