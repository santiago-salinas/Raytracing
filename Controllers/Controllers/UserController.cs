using Controllers.Exceptions;
using Services;
using Services.Exceptions;

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
            try
            {
                _userService.CheckUsernameValidity(username);
            }
            catch (Service_ArgumentException ex)
            {
                throw new Controller_ArgumentException(ex.Message);
            }
        }

        public void CheckPasswordValidity(string password)
        {
            try
            {
                _userService.CheckPasswordValidity(password);
            }
            catch (Service_ArgumentException ex)
            {
                throw new Controller_ArgumentException(ex.Message);
            }
        }
        public void SignUp(string username, string password)
        {
            try
            {
                _userService.SignUp(username, password);
            }
            catch (Service_ObjectAlreadyExistsException ex)
            {
                throw new Controller_ObjectAlreadyExistsException(ex.Message);
            }

        }

        public bool Login(string username, string password)
        {
            bool isValidCombination = _userService.Login(username, password);

            return isValidCombination;
        }

    }
}
