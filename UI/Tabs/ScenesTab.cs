using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Objects;
using BusinessLogic.Collections;
using BusinessLogic;
using UI.Cards;
using UI.Dialogs;

namespace UI.Tabs
{
    public partial class ScenesTab : Form
    {
        private User loggedUser;
        public ScenesTab(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            loadScenes();
        }

        private void loadScenes()
        {
            List<Scene> sceneList = SceneCollection.GetScenesFromUser(loggedUser);
            foreach (Scene elem in sceneList)
            {
                SceneCard sceneCard = new SceneCard(elem);
                flowLayoutPanel.Controls.Add(sceneCard);
            }
        }

        private void addSceneButton_Click(object sender, EventArgs e)
        {

        }


    }
}
