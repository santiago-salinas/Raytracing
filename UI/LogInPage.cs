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
            User user1 = new User()
            {
                UserName = "Test",
                Password = "Test1",
                RegisterDate = DateTime.Now,
                
            };

            User user2 = new User()
            {
                UserName = "Test2",
                Password = "Test1",
                RegisterDate = DateTime.Now,
            };

            User user3 = new User()
            {
                UserName = "Test3",
                Password = "Test1",
                RegisterDate = DateTime.Now,
            };
            UserCollection.AddUser(user1);
            UserCollection.AddUser(user2);
            UserCollection.AddUser(user3);


            Sphere sphere1 = new Sphere("Sphere 1", 2.5f,user1);
            Sphere sphere2 = new Sphere("Sphere 2", 3.0f,user2);
            Sphere sphere3 = new Sphere("Sphere 3", 1.8f,user3);

            SphereCollection.AddSphere(sphere1);
            SphereCollection.AddSphere(sphere2);
            SphereCollection.AddSphere(sphere3);
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
