using System;
using System.Linq;

namespace BusinessLogic
{
    public class User
    {
        private const int _minimumUsernameLength = 3;
        private const int _maximumUsernameLength = 20;
        private const int _minimumPasswordLength = 5;
        private const int _maximumPasswordLength = 25;
        private String _userName;
        private String _password;

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

        public DateTime RegisterDate { get; set; }

        public void CheckIfUserNameIsValid(string value)
        {
            if (value.Length < _minimumUsernameLength || value.Length > _maximumUsernameLength)
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
            ValidatePasswordLengthIsBetweenBounds(value);
            ValidatePasswordContainsUpperCase(value);
            ValidatePasswordContainsDigit(value);
        }

        private void ValidatePasswordLengthIsBetweenBounds(string value)
        {
            if (!(value.Length >= _minimumPasswordLength && value.Length <= _maximumPasswordLength))
            {
                throw new ArgumentException("Password must be between 5 and 25 characters long");
            }
        }

        private void ValidatePasswordContainsUpperCase(string value)
        {
            if (!value.Any(char.IsUpper))
            {
                throw new ArgumentException("Password must contain at least one upper case character");
            }
        }

        private void ValidatePasswordContainsDigit(string value)
        {
            if (!value.Any(char.IsDigit))
            {
                throw new ArgumentException("Password must contain at least one numerical digit");
            }
        }

        public override bool Equals(object other)
        {
            return this.UserName == ((User)other).UserName;
        }
    }
}
