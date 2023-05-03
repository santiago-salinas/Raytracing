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
    public partial class ModelsTab : Form
    {
        private User loggedUser;
        public ModelsTab(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            loadModels();
        }

        private void loadModels()
        {
            List<Model> lambertianList = ModelCollection.GetModelsFromUser(loggedUser);
            foreach (Model elem in lambertianList)
            {
                ModelCard modelCard = new ModelCard(elem);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addModelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
