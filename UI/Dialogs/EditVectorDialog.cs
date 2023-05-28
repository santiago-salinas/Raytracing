using System;
using System.Windows.Forms;
using DataTransferObjects;

namespace UI.Dialogs
{
    public partial class EditVectorDialog : Form
    {
        public bool WasModified;
        private VectorDTO _vector;
        public EditVectorDialog(VectorDTO providedVector, string title)
        {
            InitializeComponent();
            titleLabel.Text = title;
            _vector = providedVector;
            WasModified = false;

            xValueInput.Value = (decimal)_vector.FirstValue;
            yValueInput.Value = (decimal)_vector.SecondValue;
            zValueInput.Value = (decimal)_vector.ThirdValue;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            double newXValue = (double)xValueInput.Value;
            double newYValue = (double)yValueInput.Value;
            double newZValue = (double)zValueInput.Value;

            if (_vector.FirstValue != newXValue ||
                _vector.SecondValue != newYValue ||
                _vector.ThirdValue != newZValue)
            {
                WasModified = true;
            }

            _vector.FirstValue = newXValue;
            _vector.SecondValue = newYValue;
            _vector.ThirdValue = newZValue;

            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
