using BusinessLogic.DomainObjects;
using RepoInterfaces;
using System.Linq;

namespace DataAccess.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        public EFUserRepository() { }

        public bool ContainsUser(string name)
        {
            using (EFContext dbContext = new EFContext())
            {
                return dbContext.UserEntities
                   .Any(u =>u.Username == name);
            }
        }
        public void AddUser(User user)
        {
            using (EFContext dbContext = new EFContext())
            {
                UserEntity entity = UserEntity.FromDomain(user);
                dbContext.UserEntities.Add(entity);
                dbContext.SaveChanges();
            }
        }
        public User GetUser(string username)
        {
            using (EFContext context = new EFContext())
            {
                UserEntity userEntity = context.UserEntities
                    .FirstOrDefault(u => u.Username == username);

                return UserEntity.FromEntity(userEntity);
            }
        }
        public bool CheckUsernameAndPasswordCombination(string username, string password)
        {
            using (EFContext dbContext = new EFContext())
            {
                return dbContext.UserEntities
                   .Any(u => u.Username == username && u.Password == password);
            }
        }
    }
}
