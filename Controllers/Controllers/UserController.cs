using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UserController
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public void CheckUsernameValidity(string username)
        {
            int _minimumUsernameLength = 3;
            int _maximumUsernameLength = 20;
            if (username.Length < _minimumUsernameLength || username.Length > _maximumUsernameLength)
            {
                throw new ArgumentException("User name must be between 3 and 20 characters long");
            }

            if (username.Contains(" "))
            {
                throw new ArgumentException("User name cannot contain spaces");
            }
        }

        public void CheckPasswordValidity(string password) 
        {
            try
            {
                _userService.CheckPasswordValidity(password);
            }catch  (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void SignUp(string username, string password)
        {
            try
            {
                _userService.SignUp(username, password);
            }catch (Exception ex)   
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        public bool Login(string username, string password)
        {
            bool isValidCombination = _userService.Login(username, password);

            return isValidCombination;
        }

    }
}
