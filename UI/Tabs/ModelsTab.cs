using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class ModelsTab : Form
    {
        private User _loggedUser;
        public ModelsTab(User loggedUser)
        {
            InitializeComponent();
            this._loggedUser = loggedUser;
            LoadModels();
        }

        private void LoadModels()
        {
            List<Model> modelList = Models.GetModelsFromUser(_loggedUser);
            foreach (Model elem in modelList)
            {
                ModelCard modelCard = new ModelCard(elem);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }

        private void AddModelButton_Click(object sender, EventArgs e)
        {
            AddModelDialog addModel = new AddModelDialog(_loggedUser);
            DialogResult result = addModel.ShowDialog();

            if (result == DialogResult.OK)
            {
                ModelCard modelCard = new ModelCard(addModel.NewModel);
                Models.AddModel(addModel.NewModel);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }
    }
}
