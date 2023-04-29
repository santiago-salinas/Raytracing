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

namespace UI
{
    public partial class MainPage : Form
    {
        User loggedUser = null;
        public MainPage(User providedUser)
        {
            InitializeComponent();
            loggedUser = providedUser;
            loggedUsernameLabel.Text = loggedUser.UserName;
        }

    }
}
