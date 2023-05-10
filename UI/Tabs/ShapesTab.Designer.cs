namespace UI.Tabs
{
    partial class ShapesTab
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
            this.emptyLabel = new System.Windows.Forms.Label();
            this.addShapeButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // emptyLabel
            // 
            this.emptyLabel.AutoSize = true;
            this.emptyLabel.Location = new System.Drawing.Point(521, 304);
            this.emptyLabel.Name = "emptyLabel";
            this.emptyLabel.Size = new System.Drawing.Size(103, 13);
            this.emptyLabel.TabIndex = 0;
            this.emptyLabel.Text = "WOW such empty...";
            // 
            // addShapeButton
            // 
            this.addShapeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addShapeButton.BackColor = System.Drawing.Color.LightGray;
            this.addShapeButton.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addShapeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addShapeButton.Location = new System.Drawing.Point(453, 31);
            this.addShapeButton.Name = "addShapeButton";
            this.addShapeButton.Size = new System.Drawing.Size(371, 95);
            this.addShapeButton.TabIndex = 1;
            this.addShapeButton.Text = "     Add new shape";
            this.addShapeButton.UseVisualStyleBackColor = false;
            this.addShapeButton.Click += new System.EventHandler(this.AddShapeButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(132, 132);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1132, 676);
            this.flowLayoutPanel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Image = global::UI.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point(472, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.AddShapeButton_Click);
            // 
            // ShapesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 820);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.addShapeButton);
            this.Controls.Add(this.emptyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShapesTab";
            this.Text = "ShapesTab";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emptyLabel;
        private System.Windows.Forms.Button addShapeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}