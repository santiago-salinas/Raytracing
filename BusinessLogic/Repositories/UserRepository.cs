using System.Collections.Generic;

namespace BusinessLogic
{
    public static class UserRepository
    {
        private static List<User> s_userList = new List<User>();

        public static void Drop()
        {
            s_userList.Clear();
        }

        public static bool ContainsUser(string name)
        {
            return s_userList.Exists(u => u.UserName == name); ;
        }

        public static void AddUser(User newElement)
        {
            if (!ContainsUser(newElement.UserName))
            {
                s_userList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User with that username already exists");
            }
        }

        public static User GetUser(string username)
        {
            User ret = s_userList.Find(u => u.UserName == username);
            if (ret == null) throw new BusinessLogicException("User with that username does not exist yet");
            return ret;
        }

        public static bool CheckUsernameAndPasswordCombination(string username, string password)
        {
            return s_userList.Exists(u => u.UserName == username && u.Password == password);
        }
    }
}

