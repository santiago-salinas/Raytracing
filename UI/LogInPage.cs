using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Objects;
using BusinessLogic.Collections;
using BusinessLogic;

namespace UI
{
    public partial class LogInPage : Form
    {
        public LogInPage()
        {
            InitializeComponent();
            /*User testUser = new User()
            {
                UserName = "Test",
                Password = "TestPassword1",
                RegisterDate = DateTime.Now,
            };
            UserCollection.AddUser(testUser);*/
        }


        private void logInButton_Click(object sender, EventArgs e)
        {
            string userNameText = userNameTextBox.Text;
            string passwordText = passwordTextBox.Text;

            bool credentialsAreCorrect = UserCollection.CheckUsernameAndPasswordCombination(userNameText, passwordText);
            
            if (credentialsAreCorrect) {
                User user = UserCollection.GetUser(userNameText);
                new MainPage(user).Show();
                this.Hide();
            }
            else
            {
                logInLabel.Text = "Username and password combination is incorrect";
                userNameTextBox.Clear();
                passwordTextBox.Clear();
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            new SignUpPage().Show();
            this.Hide();
        }
    }
}
