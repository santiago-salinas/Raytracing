﻿namespace UI.Cards
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
            this.materialNameLabel.Location = new System.Drawing.Point(123, 79);
            this.materialNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialNameLabel.Name = "materialNameLabel";
            this.materialNameLabel.Size = new System.Drawing.Size(61, 16);
            this.materialNameLabel.TabIndex = 12;
            this.materialNameLabel.Text = "Material: ";
            // 
            // shapeNameLabel
            // 
            this.shapeNameLabel.AutoSize = true;
            this.shapeNameLabel.Location = new System.Drawing.Point(123, 49);
            this.shapeNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.shapeNameLabel.MaximumSize = new System.Drawing.Size(150, 0);
            this.shapeNameLabel.Name = "shapeNameLabel";
            this.shapeNameLabel.Size = new System.Drawing.Size(53, 16);
            this.shapeNameLabel.TabIndex = 11;
            this.shapeNameLabel.Text = "Shape: ";
            // 
            // modelNameLabel
            // 
            this.modelNameLabel.AutoSize = true;
            this.modelNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelNameLabel.Location = new System.Drawing.Point(119, 11);
            this.modelNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modelNameLabel.MaximumSize = new System.Drawing.Size(150, 0);
            this.modelNameLabel.Name = "modelNameLabel";
            this.modelNameLabel.Size = new System.Drawing.Size(79, 29);
            this.modelNameLabel.TabIndex = 10;
            this.modelNameLabel.Text = "label1";
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("MS PGothic", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(268, 30);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(55, 55);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(4, 4);
            this.previewBox.Margin = new System.Windows.Forms.Padding(4);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(98, 98);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 13;
            this.previewBox.TabStop = false;
            // 
            // EditSceneModelCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.materialNameLabel);
            this.Controls.Add(this.shapeNameLabel);
            this.Controls.Add(this.modelNameLabel);
            this.Name = "EditSceneModelCard";
            this.Size = new System.Drawing.Size(340, 110);
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