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
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.confirmPasswordTextbox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.signUpButton = new System.Windows.Forms.Button();
            this.passwordStatusLabel = new System.Windows.Forms.Label();
            this.usernameStatusLabel = new System.Windows.Forms.Label();
            this.confirmPasswordStatusLabel = new System.Windows.Forms.Label();
            this.signUpLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(109, 159);
            this.userNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(428, 22);
            this.userNameTextBox.TabIndex = 0;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.usernameTextBoxChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(72, 191);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 1);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(72, 353);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(467, 1);
            this.panel2.TabIndex = 8;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(109, 321);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(428, 22);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBoxChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(72, 511);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(467, 1);
            this.panel3.TabIndex = 8;
            // 
            // confirmPasswordTextbox
            // 
            this.confirmPasswordTextbox.Location = new System.Drawing.Point(109, 479);
            this.confirmPasswordTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmPasswordTextbox.Name = "confirmPasswordTextbox";
            this.confirmPasswordTextbox.PasswordChar = '*';
            this.confirmPasswordTextbox.Size = new System.Drawing.Size(428, 22);
            this.confirmPasswordTextbox.TabIndex = 2;
            this.confirmPasswordTextbox.TextChanged += new System.EventHandler(this.passwordConfirmTextBoxChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(109, 112);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(70, 16);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(109, 282);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(67, 16);
            this.passwordLabel.TabIndex = 11;
            this.passwordLabel.Text = "Password";
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(109, 433);
            this.confirmPasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(114, 16);
            this.confirmPasswordLabel.TabIndex = 12;
            this.confirmPasswordLabel.Text = "Confirm password";
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(261, 613);
            this.signUpButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(100, 28);
            this.signUpButton.TabIndex = 13;
            this.signUpButton.Text = "Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.TextChanged += new System.EventHandler(this.usernameTextBoxChanged);
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // passwordStatusLabel
            // 
            this.passwordStatusLabel.AutoSize = true;
            this.passwordStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordStatusLabel.Location = new System.Drawing.Point(132, 383);
            this.passwordStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordStatusLabel.Name = "passwordStatusLabel";
            this.passwordStatusLabel.Size = new System.Drawing.Size(0, 16);
            this.passwordStatusLabel.TabIndex = 14;
            // 
            // usernameStatusLabel
            // 
            this.usernameStatusLabel.AutoSize = true;
            this.usernameStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.usernameStatusLabel.Location = new System.Drawing.Point(132, 209);
            this.usernameStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameStatusLabel.Name = "usernameStatusLabel";
            this.usernameStatusLabel.Size = new System.Drawing.Size(0, 16);
            this.usernameStatusLabel.TabIndex = 17;
            // 
            // confirmPasswordStatusLabel
            // 
            this.confirmPasswordStatusLabel.AutoSize = true;
            this.confirmPasswordStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.confirmPasswordStatusLabel.Location = new System.Drawing.Point(132, 533);
            this.confirmPasswordStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.confirmPasswordStatusLabel.Name = "confirmPasswordStatusLabel";
            this.confirmPasswordStatusLabel.Size = new System.Drawing.Size(328, 16);
            this.confirmPasswordStatusLabel.TabIndex = 18;
            this.confirmPasswordStatusLabel.Text = "* Confirmed password and password are not the same";
            this.confirmPasswordStatusLabel.Visible = false;
            // 
            // signUpLabel
            // 
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.ForeColor = System.Drawing.Color.Red;
            this.signUpLabel.Location = new System.Drawing.Point(159, 665);
            this.signUpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(300, 16);
            this.signUpLabel.TabIndex = 19;
            this.signUpLabel.Text = "Please check text fields for necessary corrections";
            this.signUpLabel.Visible = false;
            // 
            // SignUpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 814);
            this.Controls.Add(this.signUpLabel);
            this.Controls.Add(this.confirmPasswordStatusLabel);
            this.Controls.Add(this.usernameStatusLabel);
            this.Controls.Add(this.passwordStatusLabel);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.confirmPasswordTextbox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SignUpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUpPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox confirmPasswordTextbox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.Label passwordStatusLabel;
        private System.Windows.Forms.Label usernameStatusLabel;
        private System.Windows.Forms.Label confirmPasswordStatusLabel;
        private System.Windows.Forms.Label signUpLabel;
    }
}