using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Objects
{
    public class User
    {
        private String _userName;
        private String _password;
        private DateTime _registerDate;


        public User() { }

        public String UserName
        {
            get { return _userName; }
            set
            {
                value = value.Trim();
                CheckIfUserNameIsValid(value);
                _userName = value;
            }
        }

        public String Password
        {
            get { return _password; }
            set
            {
                IsValidPassword(value);
                _password = value;
            }
        }

        public void CheckIfUserNameIsValid(string value)
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("User name must be between 3 and 20 characters long");
            }

            if (value.Contains(" "))
            {
                throw new ArgumentException("User name cannot contain spaces");
            }
        }

        public void IsValidPassword(string value)
        {
            if (!PasswordLengthIsBetweenBounds(value))
            {
                throw new ArgumentException("Password must be between 5 and 25 characters long");
            }
            if (!PasswordContainsUpperCase(value))
            {
                throw new ArgumentException("Password must contain at least one upper case character");
            }
            if (!PasswordContainsDigit(value))
            {
                throw new ArgumentException("Password must contain at least one numerical digit");
            }
        }

        private bool PasswordLengthIsBetweenBounds(string value)
        {
            return value.Length >= 5 && value.Length <= 25;
        }

        private bool PasswordContainsUpperCase(string value)
        {
            return value.Any(char.IsUpper);
        }

        private bool PasswordContainsDigit(string value)
        {
            return value.Any(char.IsDigit);
        }


        public override bool Equals(object other)
        {
            return this.UserName == ((User)other).UserName;
        }
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }

    }
}
