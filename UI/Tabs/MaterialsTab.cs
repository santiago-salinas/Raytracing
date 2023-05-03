using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Collections;
using BusinessLogic.Objects;
using UI.Cards;

namespace UI.Tabs
{
    public partial class MaterialsTab : Form
    {
        private User loggedUser;
        public MaterialsTab(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            loadMaterials();
        }

        private void loadMaterials()
        {
            List<Lambertian> lambertianList = LambertianCollection.GetLambertiansFromUser(loggedUser);
            foreach (Lambertian elem in lambertianList)
            {
                LambertianCard lambertianCard = new LambertianCard(elem);
                flowLayoutPanel.Controls.Add(lambertianCard);
            }
        }

        private void shapeLabel_Click(object sender, EventArgs e)
        {

        }

        private void addMaterialButton_Click(object sender, EventArgs e)
        {

        }
    }
}
