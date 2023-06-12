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
