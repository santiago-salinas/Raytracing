using BusinessLogic.Exceptions;
using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using RepoInterfaces;
using Services.Exceptions;

namespace Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SignUp(string username, string password)
        {

            if (_userRepository.ContainsUser(username)) throw new Service_ObjectAlreadyExistsException("Username already in use");
            else
            {
                User newUser = new User
                {
                    UserName = username,
                    Password = password,
                    RegisterDate = DateTimeProvider.Now
                };

                _userRepository.AddUser(newUser);
            }
        }

        public bool Login(string username, string password)
        {
            bool isValidCombination = _userRepository.CheckUsernameAndPasswordCombination(username, password);

            return isValidCombination;
        }

        public void CheckUsernameValidity(string username)
        {
            try
            {
                User.CheckUsernameValidity(username);
            }
            catch (BusinessLogicException ex)
            {
                throw new Service_ArgumentException(ex.Message);
            }
        }

        public void CheckPasswordValidity(string password)
        {
            try
            {
                User.CheckPasswordValidity(password);
            }
            catch (BusinessLogicException ex)
            {
                throw new Service_ArgumentException(ex.Message);
            }
        }
    }
}
