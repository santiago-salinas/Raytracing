using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLogic.Objects;

namespace BusinessLogic.Collections
{
    public static class UserCollection
    {
        private static List<User> _userList = new List<User>();

        public static void DropCollection()
        {
            _userList.Clear();
        }

        public static bool ContainsUser(string name)
        {
            return  _userList.Exists(u => u.UserName == name); ;
        }

        public static void AddUser(User newElement)
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

        public static User GetUser(string username)
        {
            User ret = _userList.Find(u => u.UserName == username);
            if (ret == null) throw new BusinessLogicException("User with that username does not exist yet");
            return ret;
        }

        public static bool CheckUsernameAndPasswordCombination(string username, string password)
        {
            return _userList.Exists(u => u.UserName == username && u.Password == password);
        }
    }
}

