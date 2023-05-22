﻿using BusinessLogic;
using System;
using System.Windows.Forms;
using Controllers;

namespace UI
{
    public partial class SignUpPage : Form
    {
        private User _createdUser = null;
        private bool _usernameFieldIsCorrect = false;
        private bool _passwordFieldIsCorrect = false;
        private bool _confirmPasswordFieldIsCorrect = false;
        private Context _context;
        private MemoryUserRepository _repository;
        public SignUpPage(Context context)
        {
            InitializeComponent();
            _createdUser = new User();
            _context = context;
            _repository = context.UserRepository;
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            usernameStatusLabel.Text = "";

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
            }
            else
            {
                signUpLabel.Visible = true;
            }

        }

        private void UsernameTextBoxChanged(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            usernameStatusLabel.Text = "";
            _usernameFieldIsCorrect = true;

            try
            {
                _createdUser.CheckIfUserNameIsValid(username);
            }
            catch (ArgumentException ex)
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
                _createdUser.IsValidPassword(password);
            }
            catch (ArgumentException ex)
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
