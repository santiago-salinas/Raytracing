namespace UI.Dialogs
{
    partial class AddSphereDialog
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
            this.newSphereLabel = new System.Windows.Forms.Label();
            this.nameStatusLabel = new System.Windows.Forms.Label();
            this.sphereNameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radiusStatusLabel = new System.Windows.Forms.Label();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radiusInput = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radiusInput)).BeginInit();
            this.SuspendLayout();
            // 
            // newSphereLabel
            // 
            this.newSphereLabel.AutoSize = true;
            this.newSphereLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newSphereLabel.Location = new System.Drawing.Point(266, 47);
            this.newSphereLabel.Name = "newSphereLabel";
            this.newSphereLabel.Size = new System.Drawing.Size(239, 46);
            this.newSphereLabel.TabIndex = 0;
            this.newSphereLabel.Text = "New Sphere";
            // 
            // nameStatusLabel
            // 
            this.nameStatusLabel.AutoSize = true;
            this.nameStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.nameStatusLabel.Location = new System.Drawing.Point(243, 202);
            this.nameStatusLabel.Name = "nameStatusLabel";
            this.nameStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.nameStatusLabel.TabIndex = 21;
            // 
            // sphereNameLabel
            // 
            this.sphereNameLabel.AutoSize = true;
            this.sphereNameLabel.Location = new System.Drawing.Point(226, 123);
            this.sphereNameLabel.Name = "sphereNameLabel";
            this.sphereNameLabel.Size = new System.Drawing.Size(72, 13);
            this.sphereNameLabel.TabIndex = 20;
            this.sphereNameLabel.Text = "Sphere Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(226, 161);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(322, 20);
            this.nameTextBox.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(198, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 1);
            this.panel1.TabIndex = 18;
            // 
            // radiusStatusLabel
            // 
            this.radiusStatusLabel.AutoSize = true;
            this.radiusStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.radiusStatusLabel.Location = new System.Drawing.Point(243, 324);
            this.radiusStatusLabel.Name = "radiusStatusLabel";
            this.radiusStatusLabel.Size = new System.Drawing.Size(134, 13);
            this.radiusStatusLabel.TabIndex = 25;
            this.radiusStatusLabel.Text = "* Radius must be over zero";
            this.radiusStatusLabel.Visible = false;
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(226, 245);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(40, 13);
            this.radiusLabel.TabIndex = 24;
            this.radiusLabel.Text = "Radius";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(198, 309);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 1);
            this.panel2.TabIndex = 22;
            // 
            // radiusInput
            // 
            this.radiusInput.Location = new System.Drawing.Point(229, 283);
            this.radiusInput.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.radiusInput.Name = "radiusInput";
            this.radiusInput.Size = new System.Drawing.Size(146, 20);
            this.radiusInput.TabIndex = 26;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(162, 372);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(150, 51);
            this.saveButton.TabIndex = 27;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(491, 372);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 51);
            this.cancelButton.TabIndex = 28;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddSphereDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.radiusInput);
            this.Controls.Add(this.radiusStatusLabel);
            this.Controls.Add(this.radiusLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.nameStatusLabel);
            this.Controls.Add(this.sphereNameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newSphereLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddSphereDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSphere";
            ((System.ComponentModel.ISupportInitialize)(this.radiusInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newSphereLabel;
        private System.Windows.Forms.Label nameStatusLabel;
        private System.Windows.Forms.Label sphereNameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label radiusStatusLabel;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown radiusInput;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}