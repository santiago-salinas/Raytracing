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
using BusinessLogic.Objects;
using BusinessLogic.Collections;

namespace UI.Cards
{
    public partial class SceneCard : UserControl
    {
        private Scene scene;
        public SceneCard(Scene scene)
        {
            InitializeComponent();
            this.scene = scene;
        }

        private void SceneCard_Load(object sender, EventArgs e)
        {

        }
    }
}
