namespace UI.Cards
{
    partial class SceneCard
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.lastModificationLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(352, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(126, 46);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "label1";
            // 
            // lastModificationLabel
            // 
            this.lastModificationLabel.AutoSize = true;
            this.lastModificationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastModificationLabel.Location = new System.Drawing.Point(355, 136);
            this.lastModificationLabel.Name = "lastModificationLabel";
            this.lastModificationLabel.Size = new System.Drawing.Size(138, 25);
            this.lastModificationLabel.TabIndex = 2;
            this.lastModificationLabel.Text = "Last modified: ";
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.DimGray;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteButton.Location = new System.Drawing.Point(848, 67);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(84, 72);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(732, 86);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 35);
            this.editButton.TabIndex = 9;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // previewPanel
            // 
            this.previewPanel.Location = new System.Drawing.Point(27, 28);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(295, 170);
            this.previewPanel.TabIndex = 10;
            // 
            // SceneCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.lastModificationLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "SceneCard";
            this.Size = new System.Drawing.Size(965, 240);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label lastModificationLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Panel previewPanel;
    }
}
