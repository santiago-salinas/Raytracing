using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Dialogs;
using UI.Cards;

namespace UI.Tabs
{
    public partial class SceneEditDialog : Form
    {
        private Scene scene;
        private User loggedUser;
        public SceneEditDialog(Scene providedScene, User providedUser)
        {
            InitializeComponent();            
            scene = providedScene;
            loggedUser = providedUser;
            nameLabel.Text = scene.Name;
            loadAvailableModels();
            loadPositionedModels();
            //lastModificationLabel += scene.LastModificationDate.ToString();
        }

        private void lookFromEditButton_Click(object sender, EventArgs e)
        {
            /*Vector providedVector = new Vector();
            EditVector editVectorDialog = new EditVector(providedVector);
            
            if (editVectorDialog.ShowDialog() == DialogResult.OK)
            {
                lookFromEditButton.Text = "";
            }*/
        }

        private void lookAtEditButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!SceneCollection.ContainsScene(nameLabel.Text, loggedUser))
            {
                this.DialogResult = DialogResult.OK;
            }

            
        }

        private void loadAvailableModels()
        {
            List<Model> list = ModelCollection.GetModelsFromUser(loggedUser);
            foreach (Model elem in list)
            {
                ModelCard modelCard = new ModelCard(elem);
                availableModelsPanel.Controls.Add(modelCard);
            }
        }

        private void loadPositionedModels()
        {
            if(scene != null)
            {
                List<PositionedModel> list = scene.PositionedModels;
                foreach (PositionedModel elem in list)
                {
                    PositionedModelCard modelCard = new PositionedModelCard(elem, scene);
                    positionedModelsPanel.Controls.Add(modelCard);
                }
            }            
            
        }
    }
}
