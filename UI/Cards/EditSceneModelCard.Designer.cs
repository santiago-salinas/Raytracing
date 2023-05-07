namespace UI.Cards
{
    partial class EditSceneModelCard
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
            this.materialNameLabel = new System.Windows.Forms.Label();
            this.shapeNameLabel = new System.Windows.Forms.Label();
            this.modelNameLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.previewBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // materialNameLabel
            // 
            this.materialNameLabel.AutoSize = true;
            this.materialNameLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialNameLabel.Location = new System.Drawing.Point(74, 61);
            this.materialNameLabel.Name = "materialNameLabel";
            this.materialNameLabel.Size = new System.Drawing.Size(67, 13);
            this.materialNameLabel.TabIndex = 12;
            this.materialNameLabel.Text = "Material: ";
            // 
            // shapeNameLabel
            // 
            this.shapeNameLabel.AutoSize = true;
            this.shapeNameLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shapeNameLabel.Location = new System.Drawing.Point(74, 42);
            this.shapeNameLabel.MaximumSize = new System.Drawing.Size(112, 0);
            this.shapeNameLabel.Name = "shapeNameLabel";
            this.shapeNameLabel.Size = new System.Drawing.Size(49, 13);
            this.shapeNameLabel.TabIndex = 11;
            this.shapeNameLabel.Text = "Shape: ";
            // 
            // modelNameLabel
            // 
            this.modelNameLabel.AutoSize = true;
            this.modelNameLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelNameLabel.Location = new System.Drawing.Point(74, 5);
            this.modelNameLabel.MaximumSize = new System.Drawing.Size(112, 0);
            this.modelNameLabel.Name = "modelNameLabel";
            this.modelNameLabel.Size = new System.Drawing.Size(63, 19);
            this.modelNameLabel.TabIndex = 10;
            this.modelNameLabel.Text = "label1";
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("MS PGothic", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(190, 29);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(41, 45);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(3, 9);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(65, 65);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 13;
            this.previewBox.TabStop = false;
            // 
            // EditSceneModelCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.materialNameLabel);
            this.Controls.Add(this.shapeNameLabel);
            this.Controls.Add(this.modelNameLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditSceneModelCard";
            this.Size = new System.Drawing.Size(255, 89);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Label materialNameLabel;
        private System.Windows.Forms.Label shapeNameLabel;
        private System.Windows.Forms.Label modelNameLabel;
        private System.Windows.Forms.Button addButton;
    }
}
