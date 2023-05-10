using BusinessLogic;
using System;
using System.Windows.Forms;
using UI.Tabs;

namespace UI.Dialogs
{
    public partial class EditVectorDialog : Form
    {
        public bool wasModified;
        private Vector vector;
        public EditVectorDialog(Vector providedVector, string title)
        {
            InitializeComponent();
            titleLabel.Text = title;
            vector = providedVector;
            wasModified = false;

            xValueInput.Value = (decimal)vector.FirstValue;
            yValueInput.Value = (decimal)vector.SecondValue;
            zValueInput.Value = (decimal)vector.ThirdValue;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            double newXValue = (double)xValueInput.Value;
            double newYValue = (double)yValueInput.Value;
            double newZValue = (double)zValueInput.Value;

            if (vector.FirstValue != newXValue ||
                vector.SecondValue != newYValue ||
                vector.ThirdValue != newZValue) {

                wasModified = true;
            }

            vector.FirstValue = newXValue;
            vector.SecondValue = newYValue;
            vector.ThirdValue = newZValue;

            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
