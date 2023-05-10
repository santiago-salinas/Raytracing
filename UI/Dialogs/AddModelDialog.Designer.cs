namespace UI.Dialogs
{
    partial class AddModelDialog
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.nameStatusLabel = new System.Windows.Forms.Label();
            this.modelNameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newModelLabel = new System.Windows.Forms.Label();
            this.shapeComboBox = new System.Windows.Forms.ComboBox();
            this.materialComboBox = new System.Windows.Forms.ComboBox();
            this.shapeLabel = new System.Windows.Forms.Label();
            this.materialLabel = new System.Windows.Forms.Label();
            this.previewCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(315, 203);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 22);
            this.label1.TabIndex = 53;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(653, 469);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 63);
            this.cancelButton.TabIndex = 46;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(215, 469);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 63);
            this.saveButton.TabIndex = 45;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // nameStatusLabel
            // 
            this.nameStatusLabel.AutoSize = true;
            this.nameStatusLabel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.nameStatusLabel.Location = new System.Drawing.Point(315, 203);
            this.nameStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameStatusLabel.Name = "nameStatusLabel";
            this.nameStatusLabel.Size = new System.Drawing.Size(0, 22);
            this.nameStatusLabel.TabIndex = 44;
            // 
            // modelNameLabel
            // 
            this.modelNameLabel.AutoSize = true;
            this.modelNameLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelNameLabel.Location = new System.Drawing.Point(304, 108);
            this.modelNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modelNameLabel.Name = "modelNameLabel";
            this.modelNameLabel.Size = new System.Drawing.Size(120, 23);
            this.modelNameLabel.TabIndex = 43;
            this.modelNameLabel.Text = "Model Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(304, 148);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(428, 31);
            this.nameTextBox.TabIndex = 42;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(267, 187);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 1);
            this.panel1.TabIndex = 41;
            // 
            // newModelLabel
            // 
            this.newModelLabel.AutoSize = true;
            this.newModelLabel.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newModelLabel.Location = new System.Drawing.Point(388, 11);
            this.newModelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newModelLabel.Name = "newModelLabel";
            this.newModelLabel.Size = new System.Drawing.Size(268, 59);
            this.newModelLabel.TabIndex = 40;
            this.newModelLabel.Text = "New Model";
            // 
            // shapeComboBox
            // 
            this.shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shapeComboBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shapeComboBox.FormattingEnabled = true;
            this.shapeComboBox.Location = new System.Drawing.Point(304, 260);
            this.shapeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.shapeComboBox.Name = "shapeComboBox";
            this.shapeComboBox.Size = new System.Drawing.Size(160, 31);
            this.shapeComboBox.TabIndex = 54;
            this.shapeComboBox.SelectedIndexChanged += new System.EventHandler(this.shapeComboBox_SelectedIndexChanged);
            // 
            // materialComboBox
            // 
            this.materialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialComboBox.FormattingEnabled = true;
            this.materialComboBox.Location = new System.Drawing.Point(304, 338);
            this.materialComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialComboBox.Name = "materialComboBox";
            this.materialComboBox.Size = new System.Drawing.Size(160, 31);
            this.materialComboBox.TabIndex = 55;
            this.materialComboBox.SelectedIndexChanged += new System.EventHandler(this.materialComboBox_SelectedIndexChanged);
            // 
            // shapeLabel
            // 
            this.shapeLabel.AutoSize = true;
            this.shapeLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shapeLabel.Location = new System.Drawing.Point(304, 236);
            this.shapeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.shapeLabel.Name = "shapeLabel";
            this.shapeLabel.Size = new System.Drawing.Size(65, 23);
            this.shapeLabel.TabIndex = 56;
            this.shapeLabel.Text = "Shape";
            // 
            // materialLabel
            // 
            this.materialLabel.AutoSize = true;
            this.materialLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel.Location = new System.Drawing.Point(304, 315);
            this.materialLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel.Name = "materialLabel";
            this.materialLabel.Size = new System.Drawing.Size(98, 23);
            this.materialLabel.TabIndex = 57;
            this.materialLabel.Text = "Material";
            // 
            // previewCheckbox
            // 
            this.previewCheckbox.AutoSize = true;
            this.previewCheckbox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewCheckbox.Location = new System.Drawing.Point(304, 396);
            this.previewCheckbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.previewCheckbox.Name = "previewCheckbox";
            this.previewCheckbox.Size = new System.Drawing.Size(208, 27);
            this.previewCheckbox.TabIndex = 58;
            this.previewCheckbox.Text = "Generate preview";
            this.previewCheckbox.UseVisualStyleBackColor = true;
            // 
            // AddModelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.ControlBox = false;
            this.Controls.Add(this.previewCheckbox);
            this.Controls.Add(this.materialLabel);
            this.Controls.Add(this.shapeLabel);
            this.Controls.Add(this.materialComboBox);
            this.Controls.Add(this.shapeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameStatusLabel);
            this.Controls.Add(this.modelNameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newModelLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddModelDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New model";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label nameStatusLabel;
        private System.Windows.Forms.Label modelNameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label newModelLabel;
        private System.Windows.Forms.ComboBox shapeComboBox;
        private System.Windows.Forms.ComboBox materialComboBox;
        private System.Windows.Forms.Label shapeLabel;
        private System.Windows.Forms.Label materialLabel;
        private System.Windows.Forms.CheckBox previewCheckbox;
    }
}