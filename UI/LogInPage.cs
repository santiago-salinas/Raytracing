using BusinessLogic;
using Controllers;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace UI
{
    public partial class LogInPage : Form
    {
        private Context _context;
        private MemoryUserRepository _userRepository;
        public LogInPage(Context context)
        {
            InitializeComponent();
            _context = context;
            _userRepository = context.UserRepository;
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string userNameText = userNameTextBox.Text;
            string passwordText = passwordTextBox.Text;

            bool credentialsAreCorrect = _userRepository.CheckUsernameAndPasswordCombination(userNameText, passwordText);

            if (credentialsAreCorrect)
            {
                User user = _userRepository.GetUser(userNameText);
                _context.CurrentUser = user.UserName;
                new MainPage(user, _context).Show();
                this.Hide();
            }
            else
            {
                logInLabel.Text = "Username and password combination is incorrect";
                userNameTextBox.Clear();
                passwordTextBox.Clear();
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            new SignUpPage(_context).Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
            base.OnFormClosing(e);
        }
    }
}
