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

namespace UI.Dialogs
{
    public partial class EditVector : Form
    {
        private Vector vector;
        public EditVector(Vector providedVector)
        {
            InitializeComponent();
            vector = providedVector;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            double x = (double)(xValueInput.Value);
            double y = (double)(yValueInput.Value);
            double z = (double)(zValueInput.Value);

            vector.FirstValue = x;
            vector.SecondValue = y;
            vector.ThirdValue = z;

            this.DialogResult = DialogResult.OK;
        }
    }
}
