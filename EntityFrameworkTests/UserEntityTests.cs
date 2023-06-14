using BusinessLogic.DomainObjects;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EntityFrameworkTests
{
    [TestClass]
    public class EFUserRepositoryTests
    {
        private EFUserRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new EFUserRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (EFContext dbContext = new EFContext())
            {
                UserEntity user = dbContext.UserEntities.FirstOrDefault(u => u.Username == "TestUser");
                if (user != null)
                {
                    dbContext.UserEntities.Remove(user);
                    dbContext.SaveChanges();
                }
            }
        }

        [TestMethod]
        public void AddUser_ValidUser_UserAdded()
        {
            User user = new User()
            {
                UserName = "TestUser",
                Password = "Password1",
                RegisterDate = DateTime.Now
            };

            _repository.AddUser(user);

            bool containsUser = _repository.ContainsUser("TestUser");
            Assert.IsTrue(containsUser);
        }

        [TestMethod]
        public void GetUser_ExistingUser_ReturnsUser()
        {
            User user = new User()
            {
                UserName = "TestUser",
                Password = "Password1",
                RegisterDate = DateTime.Now
            };

            using (EFContext dbContext = new EFContext())
            {
                UserEntity userEntity = UserEntity.FromDomain(user);
                dbContext.UserEntities.Add(userEntity);
                dbContext.SaveChanges();
            }

            User retrievedUser = _repository.GetUser("TestUser");

            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual("TestUser", retrievedUser.UserName);
            Assert.AreEqual("Password1", retrievedUser.Password);
        }

        [TestMethod]
        public void ContainsUser_ExistingUser_ReturnsTrue()
        {
            User user = new User()
            {
                UserName = "TestUser",
                Password = "Password1",
                RegisterDate = DateTime.Now
            };

            using (EFContext dbContext = new EFContext())
            {
                UserEntity userEntity = UserEntity.FromDomain(user);
                dbContext.UserEntities.Add(userEntity);
                dbContext.SaveChanges();
            }

            bool containsUser = _repository.ContainsUser("TestUser");

            Assert.IsTrue(containsUser);
        }

        [TestMethod]
        public void ContainsUser_NonexistentUser_ReturnsFalse()
        {
            bool containsUser = _repository.ContainsUser("NonexistentUser");

            Assert.IsFalse(containsUser);
        }

        [TestMethod]
        public void CheckUsernameAndPasswordCombination_CorrectCredentials_ReturnsTrue()
        {
            User user = new User()
            {
                UserName = "TestUser",
                Password = "Password1",
                RegisterDate = DateTime.Now
            };

            using (EFContext dbContext = new EFContext())
            {
                UserEntity userEntity = UserEntity.FromDomain(user);
                dbContext.UserEntities.Add(userEntity);
                dbContext.SaveChanges();
            }

            bool isValid = _repository.CheckUsernameAndPasswordCombination("TestUser", "Password1");

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void CheckUsernameAndPasswordCombination_IncorrectCredentials_ReturnsFalse()
        {
            User user = new User()
            {
                UserName = "TestUser",
                Password = "Password1",
                RegisterDate = DateTime.Now
            };

            using (EFContext dbContext = new EFContext())
            {
                UserEntity userEntity = UserEntity.FromDomain(user);
                dbContext.UserEntities.Add(userEntity);
                dbContext.SaveChanges();
            }

            bool isValid = _repository.CheckUsernameAndPasswordCombination("TestUser", "WrongPassword");

            Assert.IsFalse(isValid);
        }
    }

}
