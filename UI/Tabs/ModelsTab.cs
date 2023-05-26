using BusinessLogic;
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
    public partial class ModelsTab : Form
    {
        private string _currentUser;
        private Context _context;
        private ModelManagementController _controller;
        public ModelsTab(Context context)
        {
            InitializeComponent();
            _context = context;
            _currentUser = context.CurrentUser;
            _controller = context.ModelController;
            LoadModels();
        }

        private void LoadModels()
        {
            List<ModelDTO> modelList = _controller.GetModelsFromUser(_currentUser);
            foreach (ModelDTO elem in modelList)
            {
                ModelCard modelCard = new ModelCard(elem,_controller);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }

        private void AddModelButton_Click(object sender, EventArgs e)
        {
            AddModelDialog addModel = new AddModelDialog(_context);
            DialogResult result = addModel.ShowDialog();

            if (result == DialogResult.OK)
            {
                ModelCard modelCard = new ModelCard(addModel.NewModel,_controller);
                //_controller.AddModel(addModel.NewModel);
                flowLayoutPanel.Controls.Add(modelCard);
            }
        }
    }
}
