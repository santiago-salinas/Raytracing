using System;
using System.Windows.Forms;
using Controllers;
using Services;
using DataTransferObjects;

namespace UI
{
    public partial class SignUpPage : Form
    {
        private bool _usernameFieldIsCorrect = false;
        private bool _passwordFieldIsCorrect = false;
        private bool _confirmPasswordFieldIsCorrect = false;
        private UserController _controller;
        private Context _context;
        public SignUpPage(Context context)
        {
            InitializeComponent();            
            _controller = context.UserController;
            _context = context;
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            usernameStatusLabel.Text = "";

            if(_usernameFieldIsCorrect && _passwordFieldIsCorrect && _confirmPasswordFieldIsCorrect)
            {
                try
                {
                    _controller.SignUp(username, password);
                    this.Close();
                }
                catch (Exception ex)
                {
                    signUpLabel.Visible = true;
                    usernameStatusLabel.Text = ex.Message;
                }
            }else
            {
                signUpLabel.Visible = true;
            }
         /*   try
            {
                
            }

            if (_repository.ContainsUser(username))
            {
                usernameStatusLabel.Text = "User with that name already exists";
                _usernameFieldIsCorrect = false;
            }

            if (_usernameFieldIsCorrect && _passwordFieldIsCorrect && _confirmPasswordFieldIsCorrect)
            {
                _createdUser.UserName = username;
                _createdUser.Password = password;
                _createdUser.RegisterDate = DateTime.Now;
                _repository.AddUser(_createdUser);
                this.Close();
            }*/

        }

        private void UsernameTextBoxChanged(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            usernameStatusLabel.Text = "";
            _usernameFieldIsCorrect = true;

            try
            {
                _controller.CheckUsernameValidity(username);
            }
            catch (Exception ex)
            {
                usernameStatusLabel.Text = ex.Message;
                _usernameFieldIsCorrect = false;
            }
        }

        private void PasswordTextBoxChanged(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            passwordStatusLabel.Text = "";
            _passwordFieldIsCorrect = true;
            try
            {
                _controller.CheckPasswordValidity(password);
            }
            catch (Exception ex)
            {
                passwordStatusLabel.Text = ex.Message;
                _passwordFieldIsCorrect = false;
            }

            PasswordConfirmTextBoxChanged(sender, e);
        }

        private void PasswordConfirmTextBoxChanged(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextbox.Text;
            confirmPasswordStatusLabel.Visible = false;

            if (password != confirmPassword)
            {
                confirmPasswordStatusLabel.Visible = true;
                _confirmPasswordFieldIsCorrect = false;
            }
            else
            {
                _confirmPasswordFieldIsCorrect = true;
            }
        }

        private void GoBackButton_onClick(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            new LogInPage(_context).Show();

            base.OnFormClosing(e);
        }
    }
}
