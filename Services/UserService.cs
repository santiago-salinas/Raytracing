using BusinessLogic;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                User newUser = new User
                {
                    UserName = username,
                    Password = password
                };

                _userRepository.AddUser(newUser);
            }

            public bool Login(string username, string password)
            {
                bool isValidCombination = _userRepository.CheckUsernameAndPasswordCombination(username, password);

                return isValidCombination;
            }
    }
}
