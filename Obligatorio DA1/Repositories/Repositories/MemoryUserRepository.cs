using Repositories.Interfaces;
using System.Collections.Generic;
using BusinessLogic.Exceptions;


namespace BusinessLogic
{
    public class MemoryUserRepository : IUserRepository
    {
        private List<User> _userList = new List<User>();

        public void Drop()
        {
            _userList.Clear();
        }

        public bool ContainsUser(string name)
        {
            return _userList.Exists(u => u.UserName == name); ;
        }

        public void AddUser(User newElement)
        {
            if (!ContainsUser(newElement.UserName))
            {
                _userList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User with that username already exists");
            }
        }

        public User GetUser(string username)
        {
            User ret = _userList.Find(u => u.UserName == username);
            if (ret == null) throw new BusinessLogicException("User with that username does not exist yet");
            return ret;
        }

        public bool CheckUsernameAndPasswordCombination(string username, string password)
        {
            return _userList.Exists(u => u.UserName == username && u.Password == password);
        }
    }
}

