﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            List<Model> modelList = Models.GetModelsFromUser(loggedUser);
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
                Models.AddModel(addModel.NewModel);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }
    }
}
