using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class MaterialsTab : Form
    {
        private User _loggedUser;
        public MaterialsTab(User loggedUser)
        {
            InitializeComponent();
            this._loggedUser = loggedUser;
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            List<Lambertian> lambertianList = LambertianRepository.GetLambertiansFromUser(_loggedUser);
            foreach (Lambertian elem in lambertianList)
            {
                LambertianCard lambertianCard = new LambertianCard(elem);
                flowLayoutPanel.Controls.Add(lambertianCard);
            }
        }

        private void AddMaterialButton_Click(object sender, EventArgs e)
        {
            AddLambertianDialog addMaterial = new AddLambertianDialog(_loggedUser);
            DialogResult result = addMaterial.ShowDialog();

            if (result == DialogResult.OK)
            {
                LambertianCard materialCard = new LambertianCard(addMaterial.NewLambertian);
                LambertianRepository.AddLambertian(addMaterial.NewLambertian);
                flowLayoutPanel.Controls.Add(materialCard);
            }
        }
    }
}
