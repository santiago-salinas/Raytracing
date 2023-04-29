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
            this.userNameTextBox.Location = new System.Drawing.Point(82, 129);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(322, 20);
            this.userNameTextBox.TabIndex = 9;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.usernameTextBoxChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(54, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 1);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(54, 287);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 1);
            this.panel2.TabIndex = 8;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(82, 261);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(322, 20);
            this.passwordTextBox.TabIndex = 9;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBoxChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(54, 415);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 1);
            this.panel3.TabIndex = 8;
            // 
            // confirmPasswordTextbox
            // 
            this.confirmPasswordTextbox.Location = new System.Drawing.Point(82, 389);
            this.confirmPasswordTextbox.Name = "confirmPasswordTextbox";
            this.confirmPasswordTextbox.PasswordChar = '*';
            this.confirmPasswordTextbox.Size = new System.Drawing.Size(322, 20);
            this.confirmPasswordTextbox.TabIndex = 9;
            this.confirmPasswordTextbox.TextChanged += new System.EventHandler(this.passwordConfirmTextBoxChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(82, 91);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(82, 229);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 11;
            this.passwordLabel.Text = "Password";
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(82, 352);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(90, 13);
            this.confirmPasswordLabel.TabIndex = 12;
            this.confirmPasswordLabel.Text = "Confirm password";
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(196, 498);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(75, 23);
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
            this.passwordStatusLabel.Location = new System.Drawing.Point(99, 311);
            this.passwordStatusLabel.Name = "passwordStatusLabel";
            this.passwordStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.passwordStatusLabel.TabIndex = 14;
            // 
            // usernameStatusLabel
            // 
            this.usernameStatusLabel.AutoSize = true;
            this.usernameStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.usernameStatusLabel.Location = new System.Drawing.Point(99, 170);
            this.usernameStatusLabel.Name = "usernameStatusLabel";
            this.usernameStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.usernameStatusLabel.TabIndex = 17;
            // 
            // confirmPasswordStatusLabel
            // 
            this.confirmPasswordStatusLabel.AutoSize = true;
            this.confirmPasswordStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.confirmPasswordStatusLabel.Location = new System.Drawing.Point(99, 433);
            this.confirmPasswordStatusLabel.Name = "confirmPasswordStatusLabel";
            this.confirmPasswordStatusLabel.Size = new System.Drawing.Size(260, 13);
            this.confirmPasswordStatusLabel.TabIndex = 18;
            this.confirmPasswordStatusLabel.Text = "* Confirmed password and password are not the same";
            this.confirmPasswordStatusLabel.Visible = false;
            // 
            // signUpLabel
            // 
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.ForeColor = System.Drawing.Color.Red;
            this.signUpLabel.Location = new System.Drawing.Point(119, 540);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(240, 13);
            this.signUpLabel.TabIndex = 19;
            this.signUpLabel.Text = "Please check text fields for necessary corrections";
            this.signUpLabel.Visible = false;
            // 
            // SignUpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
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
            this.Name = "SignUpPage";
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