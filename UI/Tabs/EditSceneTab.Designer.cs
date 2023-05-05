﻿namespace UI.Tabs
{
    partial class EditSceneTab
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
            this.saveButton = new System.Windows.Forms.Button();
            this.lastModificationLabel = new System.Windows.Forms.Label();
            this.lookFromLabel = new System.Windows.Forms.Label();
            this.lookAtLabel = new System.Windows.Forms.Label();
            this.fovLabel = new System.Windows.Forms.Label();
            this.fovInput = new System.Windows.Forms.NumericUpDown();
            this.availableModelsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.positionedModelsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.availableModelsLabel = new System.Windows.Forms.Label();
            this.positionedModelsLabel = new System.Windows.Forms.Label();
            this.renderButton = new System.Windows.Forms.Button();
            this.sceneLabel = new System.Windows.Forms.Label();
            this.lastRenderLabel = new System.Windows.Forms.Label();
            this.outdatedStatusLabel = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.nameStatusLabel = new System.Windows.Forms.Label();
            this.renderPanel = new System.Windows.Forms.Panel();
            this.lookFromButton = new System.Windows.Forms.Button();
            this.lookAtButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fovInput)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(34, 29);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 77);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // lastModificationLabel
            // 
            this.lastModificationLabel.AutoSize = true;
            this.lastModificationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastModificationLabel.Location = new System.Drawing.Point(589, 58);
            this.lastModificationLabel.Name = "lastModificationLabel";
            this.lastModificationLabel.Size = new System.Drawing.Size(138, 25);
            this.lastModificationLabel.TabIndex = 2;
            this.lastModificationLabel.Text = "Last modified: ";
            // 
            // lookFromLabel
            // 
            this.lookFromLabel.AutoSize = true;
            this.lookFromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookFromLabel.Location = new System.Drawing.Point(53, 135);
            this.lookFromLabel.Name = "lookFromLabel";
            this.lookFromLabel.Size = new System.Drawing.Size(66, 16);
            this.lookFromLabel.TabIndex = 4;
            this.lookFromLabel.Text = "Look from";
            // 
            // lookAtLabel
            // 
            this.lookAtLabel.AutoSize = true;
            this.lookAtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookAtLabel.Location = new System.Drawing.Point(214, 135);
            this.lookAtLabel.Name = "lookAtLabel";
            this.lookAtLabel.Size = new System.Drawing.Size(51, 16);
            this.lookAtLabel.TabIndex = 5;
            this.lookAtLabel.Text = "Look at";
            // 
            // fovLabel
            // 
            this.fovLabel.AutoSize = true;
            this.fovLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fovLabel.Location = new System.Drawing.Point(394, 135);
            this.fovLabel.Name = "fovLabel";
            this.fovLabel.Size = new System.Drawing.Size(34, 16);
            this.fovLabel.TabIndex = 6;
            this.fovLabel.Text = "FOV";
            // 
            // fovInput
            // 
            this.fovInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fovInput.Location = new System.Drawing.Point(379, 167);
            this.fovInput.Maximum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.fovInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fovInput.Name = "fovInput";
            this.fovInput.Size = new System.Drawing.Size(120, 26);
            this.fovInput.TabIndex = 9;
            this.fovInput.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // availableModelsPanel
            // 
            this.availableModelsPanel.Location = new System.Drawing.Point(44, 265);
            this.availableModelsPanel.Name = "availableModelsPanel";
            this.availableModelsPanel.Size = new System.Drawing.Size(313, 468);
            this.availableModelsPanel.TabIndex = 10;
            // 
            // positionedModelsPanel
            // 
            this.positionedModelsPanel.Location = new System.Drawing.Point(1066, 266);
            this.positionedModelsPanel.Name = "positionedModelsPanel";
            this.positionedModelsPanel.Size = new System.Drawing.Size(277, 467);
            this.positionedModelsPanel.TabIndex = 11;
            // 
            // availableModelsLabel
            // 
            this.availableModelsLabel.AutoSize = true;
            this.availableModelsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableModelsLabel.Location = new System.Drawing.Point(44, 228);
            this.availableModelsLabel.Name = "availableModelsLabel";
            this.availableModelsLabel.Size = new System.Drawing.Size(163, 25);
            this.availableModelsLabel.TabIndex = 12;
            this.availableModelsLabel.Text = "Avilable models";
            // 
            // positionedModelsLabel
            // 
            this.positionedModelsLabel.AutoSize = true;
            this.positionedModelsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionedModelsLabel.Location = new System.Drawing.Point(1061, 228);
            this.positionedModelsLabel.Name = "positionedModelsLabel";
            this.positionedModelsLabel.Size = new System.Drawing.Size(188, 25);
            this.positionedModelsLabel.TabIndex = 13;
            this.positionedModelsLabel.Text = "Positioned models";
            // 
            // renderButton
            // 
            this.renderButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.renderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renderButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.renderButton.Location = new System.Drawing.Point(869, 216);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(145, 44);
            this.renderButton.TabIndex = 15;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = false;
            this.renderButton.Click += new System.EventHandler(this.renderButton_Click);
            // 
            // sceneLabel
            // 
            this.sceneLabel.AutoSize = true;
            this.sceneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneLabel.Location = new System.Drawing.Point(409, 228);
            this.sceneLabel.Name = "sceneLabel";
            this.sceneLabel.Size = new System.Drawing.Size(73, 25);
            this.sceneLabel.TabIndex = 16;
            this.sceneLabel.Text = "Scene";
            // 
            // lastRenderLabel
            // 
            this.lastRenderLabel.AutoSize = true;
            this.lastRenderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastRenderLabel.Location = new System.Drawing.Point(414, 665);
            this.lastRenderLabel.Name = "lastRenderLabel";
            this.lastRenderLabel.Size = new System.Drawing.Size(116, 20);
            this.lastRenderLabel.TabIndex = 17;
            this.lastRenderLabel.Text = "Last rendered: ";
            // 
            // outdatedStatusLabel
            // 
            this.outdatedStatusLabel.AutoSize = true;
            this.outdatedStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outdatedStatusLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.outdatedStatusLabel.Location = new System.Drawing.Point(414, 704);
            this.outdatedStatusLabel.Name = "outdatedStatusLabel";
            this.outdatedStatusLabel.Size = new System.Drawing.Size(378, 20);
            this.outdatedStatusLabel.TabIndex = 18;
            this.outdatedStatusLabel.Text = "* WARNING: The shown render is OUTDATED";
            this.outdatedStatusLabel.Visible = false;
            // 
            // nameTextbox
            // 
            this.nameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextbox.Location = new System.Drawing.Point(155, 43);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(404, 49);
            this.nameTextbox.TabIndex = 19;
            // 
            // nameStatusLabel
            // 
            this.nameStatusLabel.AutoSize = true;
            this.nameStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.nameStatusLabel.Location = new System.Drawing.Point(155, 99);
            this.nameStatusLabel.Name = "nameStatusLabel";
            this.nameStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.nameStatusLabel.TabIndex = 20;
            // 
            // renderPanel
            // 
            this.renderPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.renderPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.renderPanel.Location = new System.Drawing.Point(390, 266);
            this.renderPanel.Name = "renderPanel";
            this.renderPanel.Size = new System.Drawing.Size(650, 375);
            this.renderPanel.TabIndex = 21;
            // 
            // lookFromButton
            // 
            this.lookFromButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookFromButton.Location = new System.Drawing.Point(37, 161);
            this.lookFromButton.Name = "lookFromButton";
            this.lookFromButton.Size = new System.Drawing.Size(101, 38);
            this.lookFromButton.TabIndex = 22;
            this.lookFromButton.Text = "(0,0,0)";
            this.lookFromButton.UseVisualStyleBackColor = true;
            this.lookFromButton.Click += new System.EventHandler(this.lookFromEditButton_Click);
            // 
            // lookAtButton
            // 
            this.lookAtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookAtButton.Location = new System.Drawing.Point(191, 160);
            this.lookAtButton.Name = "lookAtButton";
            this.lookAtButton.Size = new System.Drawing.Size(101, 38);
            this.lookAtButton.TabIndex = 23;
            this.lookAtButton.Text = "(0,0,0)";
            this.lookAtButton.UseVisualStyleBackColor = true;
            this.lookAtButton.Click += new System.EventHandler(this.lookAtButton_Click);
            // 
            // EditSceneTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.ControlBox = false;
            this.Controls.Add(this.lookAtButton);
            this.Controls.Add(this.lookFromButton);
            this.Controls.Add(this.renderPanel);
            this.Controls.Add(this.nameStatusLabel);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.outdatedStatusLabel);
            this.Controls.Add(this.lastRenderLabel);
            this.Controls.Add(this.sceneLabel);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.positionedModelsLabel);
            this.Controls.Add(this.availableModelsLabel);
            this.Controls.Add(this.positionedModelsPanel);
            this.Controls.Add(this.availableModelsPanel);
            this.Controls.Add(this.fovInput);
            this.Controls.Add(this.fovLabel);
            this.Controls.Add(this.lookAtLabel);
            this.Controls.Add(this.lookFromLabel);
            this.Controls.Add(this.lastModificationLabel);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditSceneTab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sceneEditTab";
            ((System.ComponentModel.ISupportInitialize)(this.fovInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label lastModificationLabel;
        private System.Windows.Forms.Label lookFromLabel;
        private System.Windows.Forms.Label lookAtLabel;
        private System.Windows.Forms.Label fovLabel;
        private System.Windows.Forms.NumericUpDown fovInput;
        private System.Windows.Forms.FlowLayoutPanel availableModelsPanel;
        private System.Windows.Forms.FlowLayoutPanel positionedModelsPanel;
        private System.Windows.Forms.Label availableModelsLabel;
        private System.Windows.Forms.Label positionedModelsLabel;
        private System.Windows.Forms.Button renderButton;
        private System.Windows.Forms.Label sceneLabel;
        private System.Windows.Forms.Label lastRenderLabel;
        private System.Windows.Forms.Label outdatedStatusLabel;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label nameStatusLabel;
        private System.Windows.Forms.Panel renderPanel;
        private System.Windows.Forms.Button lookFromButton;
        private System.Windows.Forms.Button lookAtButton;
    }
}