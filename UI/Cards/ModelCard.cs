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
using BusinessLogic.Objects;
using BusinessLogic.Collections;

namespace UI.Cards
{
    public partial class ModelCard : UserControl
    {
        private Model model;
        public ModelCard(Model model)
        {
            InitializeComponent();
            this.model = model;
        }
    }
}
