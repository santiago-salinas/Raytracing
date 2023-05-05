namespace UI.Dialogs
{
    partial class EditVectorDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xValueInput = new System.Windows.Forms.NumericUpDown();
            this.yValueInput = new System.Windows.Forms.NumericUpDown();
            this.zValueInput = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zValueInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Z";
            // 
            // xValueInput
            // 
            this.xValueInput.Location = new System.Drawing.Point(78, 43);
            this.xValueInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.xValueInput.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.xValueInput.Name = "xValueInput";
            this.xValueInput.Size = new System.Drawing.Size(120, 20);
            this.xValueInput.TabIndex = 3;
            // 
            // yValueInput
            // 
            this.yValueInput.Location = new System.Drawing.Point(78, 80);
            this.yValueInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.yValueInput.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.yValueInput.Name = "yValueInput";
            this.yValueInput.Size = new System.Drawing.Size(120, 20);
            this.yValueInput.TabIndex = 4;
            // 
            // zValueInput
            // 
            this.zValueInput.Location = new System.Drawing.Point(78, 120);
            this.zValueInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.zValueInput.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.zValueInput.Name = "zValueInput";
            this.zValueInput.Size = new System.Drawing.Size(120, 20);
            this.zValueInput.TabIndex = 5;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(123, 168);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 34);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(25, 168);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 34);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // EditVectorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 242);
            this.ControlBox = false;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.zValueInput);
            this.Controls.Add(this.yValueInput);
            this.Controls.Add(this.xValueInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditVectorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditVectorDialog";
            ((System.ComponentModel.ISupportInitialize)(this.xValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zValueInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown xValueInput;
        private System.Windows.Forms.NumericUpDown yValueInput;
        private System.Windows.Forms.NumericUpDown zValueInput;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}