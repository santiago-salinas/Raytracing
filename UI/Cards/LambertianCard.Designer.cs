namespace UI.Cards
{
    partial class LambertianCard
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorPanel = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.redValueLabel = new System.Windows.Forms.Label();
            this.greenValueLabel = new System.Windows.Forms.Label();
            this.blueValueLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorPanel.Location = new System.Drawing.Point(29, 24);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(93, 86);
            this.colorPanel.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(169, 24);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(64, 25);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "label1";
            // 
            // redValueLabel
            // 
            this.redValueLabel.AutoSize = true;
            this.redValueLabel.Location = new System.Drawing.Point(171, 88);
            this.redValueLabel.Name = "redValueLabel";
            this.redValueLabel.Size = new System.Drawing.Size(21, 13);
            this.redValueLabel.TabIndex = 3;
            this.redValueLabel.Text = "R: ";
            // 
            // greenValueLabel
            // 
            this.greenValueLabel.AutoSize = true;
            this.greenValueLabel.Location = new System.Drawing.Point(242, 88);
            this.greenValueLabel.Name = "greenValueLabel";
            this.greenValueLabel.Size = new System.Drawing.Size(21, 13);
            this.greenValueLabel.TabIndex = 4;
            this.greenValueLabel.Text = "G: ";
            // 
            // blueValueLabel
            // 
            this.blueValueLabel.AutoSize = true;
            this.blueValueLabel.Location = new System.Drawing.Point(322, 88);
            this.blueValueLabel.Name = "blueValueLabel";
            this.blueValueLabel.Size = new System.Drawing.Size(20, 13);
            this.blueValueLabel.TabIndex = 5;
            this.blueValueLabel.Text = "B: ";
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.DimGray;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteButton.Location = new System.Drawing.Point(476, 43);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(56, 48);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteLabel
            // 
            this.deleteLabel.AutoSize = true;
            this.deleteLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.deleteLabel.Location = new System.Drawing.Point(288, 110);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(289, 13);
            this.deleteLabel.TabIndex = 7;
            this.deleteLabel.Text = "* You cannot delete a material that is being used by a model";
            this.deleteLabel.Visible = false;
            // 
            // LambertianCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.blueValueLabel);
            this.Controls.Add(this.greenValueLabel);
            this.Controls.Add(this.redValueLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.colorPanel);
            this.Name = "LambertianCard";
            this.Size = new System.Drawing.Size(600, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label redValueLabel;
        private System.Windows.Forms.Label greenValueLabel;
        private System.Windows.Forms.Label blueValueLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label deleteLabel;
    }
}
