namespace UI.Dialogs
{
    partial class EditVector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.xValueInput = new System.Windows.Forms.NumericUpDown();
            this.yValueInput = new System.Windows.Forms.NumericUpDown();
            this.zValueInput = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zValueInput)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(44, 38);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(43, 13);
            this.xLabel.TabIndex = 0;
            this.xLabel.Text = "X value";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(44, 124);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(43, 13);
            this.yLabel.TabIndex = 1;
            this.yLabel.Text = "Y value";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(44, 207);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(43, 13);
            this.zLabel.TabIndex = 2;
            this.zLabel.Text = "Z value";
            // 
            // xValueInput
            // 
            this.xValueInput.Location = new System.Drawing.Point(46, 66);
            this.xValueInput.Name = "xValueInput";
            this.xValueInput.Size = new System.Drawing.Size(120, 20);
            this.xValueInput.TabIndex = 3;
            // 
            // yValueInput
            // 
            this.yValueInput.Location = new System.Drawing.Point(46, 158);
            this.yValueInput.Name = "yValueInput";
            this.yValueInput.Size = new System.Drawing.Size(120, 20);
            this.yValueInput.TabIndex = 4;
            // 
            // zValueInput
            // 
            this.zValueInput.Location = new System.Drawing.Point(46, 235);
            this.zValueInput.Name = "zValueInput";
            this.zValueInput.Size = new System.Drawing.Size(120, 20);
            this.zValueInput.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(69, 298);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // EditVector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 356);
            this.ControlBox = false;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.zValueInput);
            this.Controls.Add(this.yValueInput);
            this.Controls.Add(this.xValueInput);
            this.Controls.Add(this.zLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditVector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditVector";
            ((System.ComponentModel.ISupportInitialize)(this.xValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zValueInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.NumericUpDown xValueInput;
        private System.Windows.Forms.NumericUpDown yValueInput;
        private System.Windows.Forms.NumericUpDown zValueInput;
        private System.Windows.Forms.Button saveButton;
    }
}