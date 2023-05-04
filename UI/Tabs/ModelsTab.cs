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
using UI.Dialogs;

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
            List<Model> modelList = ModelCollection.GetModelsFromUser(loggedUser);
            foreach (Model elem in modelList)
            {
                ModelCard modelCard = new ModelCard(elem);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }

        private void addModelButton_Click(object sender, EventArgs e)
        {
            AddModelDialog addModel = new AddModelDialog(loggedUser);
            DialogResult result = addModel.ShowDialog();

            if (result == DialogResult.OK)
            {
                ModelCard modelCard = new ModelCard(addModel.NewModel);
                ModelCollection.AddModel(addModel.NewModel);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }
    }
}
