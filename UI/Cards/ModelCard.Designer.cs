﻿namespace UI.Cards
{
    partial class ModelCard
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
            this.modelNameLabel = new System.Windows.Forms.Label();
            this.shapeNameLabel = new System.Windows.Forms.Label();
            this.materialNameLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteLabel = new System.Windows.Forms.Label();
            this.previewBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // modelNameLabel
            // 
            this.modelNameLabel.AutoSize = true;
            this.modelNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelNameLabel.Location = new System.Drawing.Point(159, 12);
            this.modelNameLabel.Name = "modelNameLabel";
            this.modelNameLabel.Size = new System.Drawing.Size(86, 31);
            this.modelNameLabel.TabIndex = 1;
            this.modelNameLabel.Text = "label1";
            this.modelNameLabel.Click += new System.EventHandler(this.modelNameLabel_Click);
            // 
            // shapeNameLabel
            // 
            this.shapeNameLabel.AutoSize = true;
            this.shapeNameLabel.Location = new System.Drawing.Point(167, 55);
            this.shapeNameLabel.Name = "shapeNameLabel";
            this.shapeNameLabel.Size = new System.Drawing.Size(44, 13);
            this.shapeNameLabel.TabIndex = 2;
            this.shapeNameLabel.Text = "Shape: ";
            this.shapeNameLabel.Click += new System.EventHandler(this.shapeNameLabel_Click);
            // 
            // materialNameLabel
            // 
            this.materialNameLabel.AutoSize = true;
            this.materialNameLabel.Location = new System.Drawing.Point(167, 85);
            this.materialNameLabel.Name = "materialNameLabel";
            this.materialNameLabel.Size = new System.Drawing.Size(50, 13);
            this.materialNameLabel.TabIndex = 3;
            this.materialNameLabel.Text = "Material: ";
            this.materialNameLabel.Click += new System.EventHandler(this.materialNameLabel_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.DimGray;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteButton.Location = new System.Drawing.Point(511, 40);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(56, 48);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteLabel
            // 
            this.deleteLabel.AutoSize = true;
            this.deleteLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.deleteLabel.Location = new System.Drawing.Point(291, 109);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(282, 13);
            this.deleteLabel.TabIndex = 8;
            this.deleteLabel.Text = "* You cannot delete a model that is being used by a scene";
            this.deleteLabel.Visible = false;
            this.deleteLabel.Click += new System.EventHandler(this.deleteLabel_Click);
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(19, 12);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(110, 110);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 9;
            this.previewBox.TabStop = false;
            // 
            // ModelCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.deleteLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.materialNameLabel);
            this.Controls.Add(this.shapeNameLabel);
            this.Controls.Add(this.modelNameLabel);
            this.Name = "ModelCard";
            this.Size = new System.Drawing.Size(600, 140);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label modelNameLabel;
        private System.Windows.Forms.Label shapeNameLabel;
        private System.Windows.Forms.Label materialNameLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label deleteLabel;
        private System.Windows.Forms.PictureBox previewBox;
    }
}