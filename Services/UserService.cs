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

            if (_userRepository.ContainsUser(username)) throw new Exception("Username already in use");
            else
            {
                try
                {
                    User newUser = new User
                    {
                        UserName = username,
                        Password = password,
                        RegisterDate = DateTimeProvider.Now
                    };

                    _userRepository.AddUser(newUser);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
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
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public void CheckPasswordValidity(string password)
        {            
            try
            {
                User.CheckPasswordValidity(password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
