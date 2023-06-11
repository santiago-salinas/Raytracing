using BusinessLogic.Exceptions;
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
        private string _userName;
        private string _password;

        public User() { }

        public string UserName
        {
            get { return _userName; }
            set
            {
                value = value.Trim();
                CheckUsernameValidity(value);
                _userName = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                CheckPasswordValidity(value);
                _password = value;
            }
        }

        public DateTime RegisterDate { get; set; }

        public static void CheckUsernameValidity(string value)
        {
            if (value.Length < _minimumUsernameLength || value.Length > _maximumUsernameLength)
            {
                throw new BusinessLogicException("User name must be between 3 and 20 characters long");
            }

            if (value.Contains(" "))
            {
                throw new BusinessLogicException("User name cannot contain spaces");
            }
        }

        public static void CheckPasswordValidity(string value)
        {
            ValidatePasswordLengthIsBetweenBounds(value);
            ValidatePasswordContainsUpperCase(value);
            ValidatePasswordContainsDigit(value);
        }

        private static void ValidatePasswordLengthIsBetweenBounds(string value)
        {
            if (!(value.Length >= _minimumPasswordLength && value.Length <= _maximumPasswordLength))
            {
                throw new BusinessLogicException("Password must be between 5 and 25 characters long");
            }
        }

        private static void ValidatePasswordContainsUpperCase(string value)
        {
            if (!value.Any(char.IsUpper))
            {
                throw new BusinessLogicException("Password must contain at least one upper case character");
            }
        }

        private static void ValidatePasswordContainsDigit(string value)
        {
            if (!value.Any(char.IsDigit))
            {
                throw new BusinessLogicException("Password must contain at least one numerical digit");
            }
        }

        public override bool Equals(object other)
        {
            return this.UserName == ((User)other).UserName;
        }
    }
}
