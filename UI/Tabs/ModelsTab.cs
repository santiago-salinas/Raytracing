using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Cards;
using UI.Dialogs;
using Controllers;

namespace UI.Tabs
{
    public partial class ModelsTab : Form
    {
        private string _currentUser;
        private Context _context;
        public ModelsTab(Context context)
        {
            InitializeComponent();
            _context = context;
            _currentUser = context.CurrentUser;
            LoadModels();
        }

        private void LoadModels()
        {
            List<Model> modelList = ModelRepository.GetModelsFromUser(_currentUser);
            foreach (Model elem in modelList)
            {
                ModelCard modelCard = new ModelCard(elem);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }

        private void AddModelButton_Click(object sender, EventArgs e)
        {
            AddModelDialog addModel = new AddModelDialog(_context);
            DialogResult result = addModel.ShowDialog();

            if (result == DialogResult.OK)
            {
                ModelCard modelCard = new ModelCard(addModel.NewModel);
                ModelRepository.AddModel(addModel.NewModel);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }
    }
}
