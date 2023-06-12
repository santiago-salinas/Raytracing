using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Objects;

namespace RepoInterfaces
{
    public interface IUserRepository
    {
        bool ContainsUser(string name);
        void AddUser(User newElement);
        User GetUser(string username);
        bool CheckUsernameAndPasswordCombination(string username, string password);
    }

}
