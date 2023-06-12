namespace UI.Dialogs
{
    partial class AddMaterialDialog
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
            this.newMaterialLabel = new System.Windows.Forms.Label();
            this.materialNameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.redLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            this.redValueInput = new System.Windows.Forms.NumericUpDown();
            this.greenValueInput = new System.Windows.Forms.NumericUpDown();
            this.blueValueInput = new System.Windows.Forms.NumericUpDown();
            this.statusLabel = new System.Windows.Forms.Label();
            this.metallicCheck = new System.Windows.Forms.CheckBox();
            this.roughnessInput = new System.Windows.Forms.NumericUpDown();
            this.roughnessLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.redValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roughnessInput)).BeginInit();
            this.SuspendLayout();
            // 
            // newMaterialLabel
            // 
            this.newMaterialLabel.AutoSize = true;
            this.newMaterialLabel.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMaterialLabel.Location = new System.Drawing.Point(258, 9);
            this.newMaterialLabel.Name = "newMaterialLabel";
            this.newMaterialLabel.Size = new System.Drawing.Size(284, 47);
            this.newMaterialLabel.TabIndex = 0;
            this.newMaterialLabel.Text = "New Material";
            // 
            // materialNameLabel
            // 
            this.materialNameLabel.AutoSize = true;
            this.materialNameLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialNameLabel.Location = new System.Drawing.Point(229, 79);
            this.materialNameLabel.Name = "materialNameLabel";
            this.materialNameLabel.Size = new System.Drawing.Size(126, 19);
            this.materialNameLabel.TabIndex = 20;
            this.materialNameLabel.Text = "Material Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(229, 117);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(322, 26);
            this.nameTextBox.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(201, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 1);
            this.panel1.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(162, 372);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(150, 51);
            this.saveButton.TabIndex = 27;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(491, 372);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 51);
            this.cancelButton.TabIndex = 28;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redLabel.Location = new System.Drawing.Point(227, 178);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(108, 19);
            this.redLabel.TabIndex = 32;
            this.redLabel.Text = "Red value: ";
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greenLabel.Location = new System.Drawing.Point(226, 229);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(126, 19);
            this.greenLabel.TabIndex = 33;
            this.greenLabel.Text = "Green value: ";
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blueLabel.Location = new System.Drawing.Point(227, 283);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(117, 19);
            this.blueLabel.TabIndex = 34;
            this.blueLabel.Text = "Blue value: ";
            // 
            // redValueInput
            // 
            this.redValueInput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redValueInput.Location = new System.Drawing.Point(337, 176);
            this.redValueInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redValueInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.redValueInput.Name = "redValueInput";
            this.redValueInput.Size = new System.Drawing.Size(120, 26);
            this.redValueInput.TabIndex = 35;
            // 
            // greenValueInput
            // 
            this.greenValueInput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greenValueInput.Location = new System.Drawing.Point(337, 227);
            this.greenValueInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenValueInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.greenValueInput.Name = "greenValueInput";
            this.greenValueInput.Size = new System.Drawing.Size(120, 26);
            this.greenValueInput.TabIndex = 36;
            // 
            // blueValueInput
            // 
            this.blueValueInput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blueValueInput.Location = new System.Drawing.Point(337, 281);
            this.blueValueInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueValueInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.blueValueInput.Name = "blueValueInput";
            this.blueValueInput.Size = new System.Drawing.Size(120, 26);
            this.blueValueInput.TabIndex = 37;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(229, 338);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 19);
            this.statusLabel.TabIndex = 39;
            // 
            // metallicCheck
            // 
            this.metallicCheck.AutoSize = true;
            this.metallicCheck.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metallicCheck.Location = new System.Drawing.Point(540, 260);
            this.metallicCheck.Name = "metallicCheck";
            this.metallicCheck.Size = new System.Drawing.Size(100, 23);
            this.metallicCheck.TabIndex = 40;
            this.metallicCheck.Text = "Metallic";
            this.metallicCheck.UseVisualStyleBackColor = true;
            this.metallicCheck.CheckedChanged += new System.EventHandler(this.metallicCheck_CheckedChanged);
            // 
            // roughnessInput
            // 
            this.roughnessInput.DecimalPlaces = 2;
            this.roughnessInput.Enabled = false;
            this.roughnessInput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roughnessInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.roughnessInput.Location = new System.Drawing.Point(537, 228);
            this.roughnessInput.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roughnessInput.Name = "roughnessInput";
            this.roughnessInput.Size = new System.Drawing.Size(120, 26);
            this.roughnessInput.TabIndex = 41;
            // 
            // roughnessLabel
            // 
            this.roughnessLabel.AutoSize = true;
            this.roughnessLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roughnessLabel.Location = new System.Drawing.Point(534, 200);
            this.roughnessLabel.Name = "roughnessLabel";
            this.roughnessLabel.Size = new System.Drawing.Size(90, 19);
            this.roughnessLabel.TabIndex = 42;
            this.roughnessLabel.Text = "Roughness";
            // 
            // AddMaterialDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.roughnessLabel);
            this.Controls.Add(this.roughnessInput);
            this.Controls.Add(this.metallicCheck);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.blueValueInput);
            this.Controls.Add(this.greenValueInput);
            this.Controls.Add(this.redValueInput);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.materialNameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newMaterialLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddMaterialDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New material";
            ((System.ComponentModel.ISupportInitialize)(this.redValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roughnessInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newMaterialLabel;
        private System.Windows.Forms.Label materialNameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.NumericUpDown redValueInput;
        private System.Windows.Forms.NumericUpDown greenValueInput;
        private System.Windows.Forms.NumericUpDown blueValueInput;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox metallicCheck;
        private System.Windows.Forms.NumericUpDown roughnessInput;
        private System.Windows.Forms.Label roughnessLabel;
    }
}