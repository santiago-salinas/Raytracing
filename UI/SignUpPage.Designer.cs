namespace UI
{
    partial class SignUpPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpPage));
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextbox = new System.Windows.Forms.TextBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.passwordStatusLabel = new System.Windows.Forms.Label();
            this.usernameStatusLabel = new System.Windows.Forms.Label();
            this.confirmPasswordStatusLabel = new System.Windows.Forms.Label();
            this.signUpLabel = new System.Windows.Forms.Label();
            this.Banner = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.goBackButton = new System.Windows.Forms.Button();
            this.Banner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameTextBox.Location = new System.Drawing.Point(87, 316);
            this.userNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(461, 27);
            this.userNameTextBox.TabIndex = 0;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBoxChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(87, 428);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(461, 27);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxChanged);
            // 
            // confirmPasswordTextbox
            // 
            this.confirmPasswordTextbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTextbox.Location = new System.Drawing.Point(87, 540);
            this.confirmPasswordTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmPasswordTextbox.Name = "confirmPasswordTextbox";
            this.confirmPasswordTextbox.PasswordChar = '*';
            this.confirmPasswordTextbox.Size = new System.Drawing.Size(461, 27);
            this.confirmPasswordTextbox.TabIndex = 2;
            this.confirmPasswordTextbox.TextChanged += new System.EventHandler(this.PasswordConfirmTextBoxChanged);
            // 
            // signUpButton
            // 
            this.signUpButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpButton.Location = new System.Drawing.Point(221, 615);
            this.signUpButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(179, 31);
            this.signUpButton.TabIndex = 13;
            this.signUpButton.Text = "Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.TextChanged += new System.EventHandler(this.UsernameTextBoxChanged);
            this.signUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // passwordStatusLabel
            // 
            this.passwordStatusLabel.AutoSize = true;
            this.passwordStatusLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordStatusLabel.Location = new System.Drawing.Point(83, 468);
            this.passwordStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordStatusLabel.Name = "passwordStatusLabel";
            this.passwordStatusLabel.Size = new System.Drawing.Size(423, 20);
            this.passwordStatusLabel.TabIndex = 14;
            this.passwordStatusLabel.Text = resources.GetString("passwordStatusLabel.Text");
            // 
            // usernameStatusLabel
            // 
            this.usernameStatusLabel.AutoSize = true;
            this.usernameStatusLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.usernameStatusLabel.Location = new System.Drawing.Point(83, 356);
            this.usernameStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameStatusLabel.Name = "usernameStatusLabel";
            this.usernameStatusLabel.Size = new System.Drawing.Size(423, 20);
            this.usernameStatusLabel.TabIndex = 17;
            this.usernameStatusLabel.Text = resources.GetString("usernameStatusLabel.Text");
            // 
            // confirmPasswordStatusLabel
            // 
            this.confirmPasswordStatusLabel.AutoSize = true;
            this.confirmPasswordStatusLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.confirmPasswordStatusLabel.Location = new System.Drawing.Point(83, 582);
            this.confirmPasswordStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.confirmPasswordStatusLabel.Name = "confirmPasswordStatusLabel";
            this.confirmPasswordStatusLabel.Size = new System.Drawing.Size(441, 20);
            this.confirmPasswordStatusLabel.TabIndex = 18;
            this.confirmPasswordStatusLabel.Text = "Confirmed password and password are not the same";
            this.confirmPasswordStatusLabel.Visible = false;
            // 
            // signUpLabel
            // 
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLabel.ForeColor = System.Drawing.Color.Red;
            this.signUpLabel.Location = new System.Drawing.Point(83, 665);
            this.signUpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(459, 20);
            this.signUpLabel.TabIndex = 19;
            this.signUpLabel.Text = "Please check text fields for necessary corrections";
            this.signUpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.signUpLabel.Visible = false;
            // 
            // Banner
            // 
            this.Banner.BackColor = System.Drawing.Color.Gainsboro;
            this.Banner.Controls.Add(this.Logo);
            this.Banner.Dock = System.Windows.Forms.DockStyle.Top;
            this.Banner.Location = new System.Drawing.Point(0, 0);
            this.Banner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Banner.Name = "Banner";
            this.Banner.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.Banner.Size = new System.Drawing.Size(645, 230);
            this.Banner.TabIndex = 20;
            // 
            // Logo
            // 
            this.Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(13, 12);
            this.Logo.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(619, 206);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.Location = new System.Drawing.Point(81, 283);
            this.UserLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(74, 32);
            this.UserLabel.TabIndex = 12;
            this.UserLabel.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 395);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 32);
            this.label1.TabIndex = 21;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 507);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 32);
            this.label2.TabIndex = 22;
            this.label2.Text = "Confirm Password";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(87, 390);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 1);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(87, 502);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(467, 1);
            this.panel2.TabIndex = 24;
            // 
            // goBackButton
            // 
            this.goBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackButton.Location = new System.Drawing.Point(13, 238);
            this.goBackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(123, 42);
            this.goBackButton.TabIndex = 25;
            this.goBackButton.Text = "<< Go Back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.GoBackButton_onClick);
            // 
            // SignUpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 716);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.Banner);
            this.Controls.Add(this.signUpLabel);
            this.Controls.Add(this.confirmPasswordStatusLabel);
            this.Controls.Add(this.usernameStatusLabel);
            this.Controls.Add(this.passwordStatusLabel);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.confirmPasswordTextbox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SignUpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign up";
            this.Banner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextbox;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.Label passwordStatusLabel;
        private System.Windows.Forms.Label usernameStatusLabel;
        private System.Windows.Forms.Label confirmPasswordStatusLabel;
        private System.Windows.Forms.Label signUpLabel;
        private System.Windows.Forms.Panel Banner;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button goBackButton;
    }
}