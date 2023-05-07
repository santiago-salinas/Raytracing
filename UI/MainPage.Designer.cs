namespace UI
{
    partial class MainPage
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
            this.shapesSideBarButton = new System.Windows.Forms.Button();
            this.materialsSideBarButton = new System.Windows.Forms.Button();
            this.modelsSideBarButton = new System.Windows.Forms.Button();
            this.scenesSideBarButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loggedUsernameLabel = new System.Windows.Forms.Label();
            this.signOutButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // shapesSideBarButton
            // 
            this.shapesSideBarButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.shapesSideBarButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shapesSideBarButton.Location = new System.Drawing.Point(0, 89);
            this.shapesSideBarButton.Name = "shapesSideBarButton";
            this.shapesSideBarButton.Size = new System.Drawing.Size(200, 93);
            this.shapesSideBarButton.TabIndex = 1;
            this.shapesSideBarButton.Text = "Shapes";
            this.shapesSideBarButton.UseVisualStyleBackColor = true;
            this.shapesSideBarButton.Click += new System.EventHandler(this.shapesSideBarButton_Click);
            // 
            // materialsSideBarButton
            // 
            this.materialsSideBarButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialsSideBarButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialsSideBarButton.Location = new System.Drawing.Point(0, 0);
            this.materialsSideBarButton.Name = "materialsSideBarButton";
            this.materialsSideBarButton.Size = new System.Drawing.Size(200, 89);
            this.materialsSideBarButton.TabIndex = 0;
            this.materialsSideBarButton.Text = "Materials";
            this.materialsSideBarButton.UseVisualStyleBackColor = true;
            this.materialsSideBarButton.Click += new System.EventHandler(this.materialsSideBarButton_Click);
            // 
            // modelsSideBarButton
            // 
            this.modelsSideBarButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.modelsSideBarButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelsSideBarButton.Location = new System.Drawing.Point(0, 182);
            this.modelsSideBarButton.Name = "modelsSideBarButton";
            this.modelsSideBarButton.Size = new System.Drawing.Size(200, 89);
            this.modelsSideBarButton.TabIndex = 2;
            this.modelsSideBarButton.Text = "Models";
            this.modelsSideBarButton.UseVisualStyleBackColor = true;
            this.modelsSideBarButton.Click += new System.EventHandler(this.modelsSideBarButton_Click);
            // 
            // scenesSideBarButton
            // 
            this.scenesSideBarButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.scenesSideBarButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scenesSideBarButton.Location = new System.Drawing.Point(0, 271);
            this.scenesSideBarButton.Name = "scenesSideBarButton";
            this.scenesSideBarButton.Size = new System.Drawing.Size(200, 89);
            this.scenesSideBarButton.TabIndex = 3;
            this.scenesSideBarButton.Text = "Scenes";
            this.scenesSideBarButton.UseVisualStyleBackColor = true;
            this.scenesSideBarButton.Click += new System.EventHandler(this.scenesSideBarButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.signOutButton);
            this.panel1.Controls.Add(this.scenesSideBarButton);
            this.panel1.Controls.Add(this.modelsSideBarButton);
            this.panel1.Controls.Add(this.shapesSideBarButton);
            this.panel1.Controls.Add(this.materialsSideBarButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 781);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.loggedUsernameLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 76);
            this.panel2.TabIndex = 0;
            // 
            // loggedUsernameLabel
            // 
            this.loggedUsernameLabel.AutoSize = true;
            this.loggedUsernameLabel.Location = new System.Drawing.Point(67, 31);
            this.loggedUsernameLabel.Name = "loggedUsernameLabel";
            this.loggedUsernameLabel.Size = new System.Drawing.Size(63, 19);
            this.loggedUsernameLabel.TabIndex = 0;
            this.loggedUsernameLabel.Text = "label1";
            this.loggedUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signOutButton
            // 
            this.signOutButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.signOutButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutButton.Location = new System.Drawing.Point(0, 730);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(200, 51);
            this.signOutButton.TabIndex = 4;
            this.signOutButton.Text = "Sign Out";
            this.signOutButton.UseVisualStyleBackColor = true;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 781);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main page";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button scenesSideBarButton;
        private System.Windows.Forms.Button modelsSideBarButton;
        private System.Windows.Forms.Button materialsSideBarButton;
        private System.Windows.Forms.Button shapesSideBarButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button signOutButton;
        private System.Windows.Forms.Label loggedUsernameLabel;
        private System.Windows.Forms.Panel panel2;
    }
}