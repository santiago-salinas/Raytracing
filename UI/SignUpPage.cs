﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Collections;
using BusinessLogic.Objects;

namespace UI
{
    public partial class SignUpPage : Form
    {
        User createdUser = null;
        bool usernameFieldIsCorrect = false;
        bool passwordFieldIsCorrect = false;
        bool confirmPasswordFieldIsCorrect = false;
        public SignUpPage()
        {
            InitializeComponent();
            createdUser = new User();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextbox.Text;
            if(usernameFieldIsCorrect && passwordFieldIsCorrect && confirmPasswordFieldIsCorrect)
            {
                createdUser.UserName = username;
                createdUser.Password = password;
                createdUser.RegisterDate = DateTime.Now;
                UserCollection.AddUser(createdUser);
                new LogInPage().Show();
                this.Close();
            }
            else
            {
                signUpLabel.Visible = true;                
            }

        }

        private void usernameTextBoxChanged(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            usernameStatusLabel.Text = "";
            usernameFieldIsCorrect = true;

            try
            {
                createdUser.CheckIfUserNameIsValid(username);
            }catch(ArgumentException ex)
            {
                usernameStatusLabel.Text = ex.Message;
                usernameFieldIsCorrect = false;
            }

        }

        private void passwordTextBoxChanged(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            passwordStatusLabel.Text = "";
            passwordFieldIsCorrect = true;
            try
            {
                createdUser.IsValidPassword(password);
            }
            catch (ArgumentException ex)
            {
                passwordStatusLabel.Text = ex.Message;
                passwordFieldIsCorrect = false;
            }

            passwordConfirmTextBoxChanged(sender, e);
        }

        private void passwordConfirmTextBoxChanged(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextbox.Text;
            confirmPasswordStatusLabel.Visible = false;

            if (password != confirmPassword)
            {
                confirmPasswordStatusLabel.Visible = true;
                confirmPasswordFieldIsCorrect = false;
            }
            else
            {
                confirmPasswordFieldIsCorrect = true;
            }
        }

    }
}
