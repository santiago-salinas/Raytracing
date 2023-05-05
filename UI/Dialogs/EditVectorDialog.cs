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
    public partial class EditVectorDialog : Form
    {
        public Vector vector;
        public EditVectorDialog(Vector providedVector, string title)
        {
            InitializeComponent();
            titleLabel.Text = title;
            vector = providedVector;
            xValueInput.Value = (decimal)vector.FirstValue;
            yValueInput.Value = (decimal)vector.SecondValue;
            zValueInput.Value = (decimal)vector.ThirdValue;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            vector.FirstValue = (double)xValueInput.Value;
            vector.SecondValue = (double)yValueInput.Value;
            vector.ThirdValue = (double)zValueInput.Value;

            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
