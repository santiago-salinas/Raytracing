using BusinessLogic;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class EFUserRepository : IUserRepository
    {
        public EFUserRepository() { }

        public bool ContainsUser(string name)
        {
            using (EFContext dbContext = new EFContext())
            {
                var query = $"SELECT * " +
                            $"FROM UserEntities " +
                            $"WHERE Username = '{name}'";
                UserEntity entityUser = dbContext.UserEntities.SqlQuery(query).FirstOrDefault();
                return entityUser != null;
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
            User domainUser = null;

            using (EFContext dbContext = new EFContext())
            {
                var query = $"SELECT * " +
                            $"FROM UserEntities " +
                            $"WHERE Username = '{username}' ";
                UserEntity userEntity = dbContext.UserEntities.SqlQuery(query).FirstOrDefault();

                if (userEntity != null)
                {
                    domainUser = UserEntity.FromEntity(userEntity);
                }
            }
            return domainUser;
        }
        public bool CheckUsernameAndPasswordCombination(string username, string password)
        {
            UserEntity userEntity = null;

            using (EFContext dbContext = new EFContext())
            {
                var query = $"SELECT * " +
                            $"FROM UserEntities " +
                            $"WHERE Username = '{username}' AND Password = '{password}' ";
                userEntity = dbContext.UserEntities.SqlQuery(query).FirstOrDefault();
            }

            return userEntity != null;
        }
    }
}
