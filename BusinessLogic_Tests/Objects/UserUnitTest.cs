﻿using BusinessLogic;
using BusinessLogic.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RepoInterfaces;
using Repositories;
using BusinessLogic.Objects;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class UserTests
    {
        private User _testUser;
        private String _testUserName;
        private String _testPassword;

        private MemoryUserRepository memoryUserRepository;
        private MemorySceneRepository memorySceneRepository;
        private MemoryModelRepository memoryModelRepository;
        private MemorySphereRepository memorySphereRepository;
        private MemoryMaterialRepository memoryMaterialRepository;

        [TestInitialize]
        public void Initialize()
        {
            memoryUserRepository = new MemoryUserRepository();
            memorySceneRepository = new MemorySceneRepository();
            memoryModelRepository = new MemoryModelRepository(memorySceneRepository);
            memorySphereRepository = new MemorySphereRepository(memoryModelRepository);
            memoryMaterialRepository = new MemoryMaterialRepository(memoryModelRepository);

            _testUserName = "TestUsername";
            _testPassword = "Abc123";
            _testUser = new User()
            {
                UserName = _testUserName,
                Password = _testPassword
            };
            DateTimeProvider.Reset();
        }

        [TestCleanup]
        public void Cleanup()
        {
            memoryUserRepository.Drop();
        }

        [TestMethod]
        public void CreatedValidUser()
        {
            // Arrange
            _testUserName = "TestUsername";
            _testPassword = "Abc123";

            // Act
            _testUser = new User()
            {
                UserName = _testUserName,
                Password = _testPassword,
                RegisterDate = DateTimeProvider.Now
            };

            // Assert
            Assert.IsNotNull(_testUserName);

        }

        [TestMethod]
        public void RegistrationDateIsCorrect()
        {
            _testUser = new User()
            {
                UserName = _testUserName,
                Password = _testPassword,
                RegisterDate = DateTimeProvider.Now
            };

            Assert.AreEqual(DateTimeProvider.Now, _testUser.RegisterDate);

        }


        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + _testUserName;
            //act
            _testUser.UserName = nameWithLeftPadding;
            //assert
            Assert.AreEqual(_testUser.UserName, _testUserName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = _testUserName + " ";
            //act
            _testUser.UserName = nameWithRightPadding;
            //assert
            Assert.AreEqual(_testUser.UserName, _testUserName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + _testUserName + " ";
            //act
            _testUser.UserName = nameWithPaddings;
            //assert
            Assert.AreEqual(_testUser.UserName, _testUserName);
        }

        [TestMethod]
        public void CheckIfUserNameIsValid_UserNameContainsSpace_ArgumentExceptionThrown()
        {
            // Arrange
            string invalidUserName = "user name with space";

            // Act
            Action act = () => _testUser.UserName = invalidUserName;
            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("User name cannot contain spaces", exception.Message);
        }

        [TestMethod]
        public void UserNameTooShortThrowsException()
        {
            // Arrange
            String invalidUserName = "aA";

            // Act
            Action act = () => _testUser.UserName = invalidUserName;

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("User name must be between 3 and 20 characters long", exception.Message);

        }

        [TestMethod]
        public void UserNameTooLongThrowsException()
        {
            // Arrange
            String invalidUserName = "abcdefghijklmnopqrstuvwxyz";

            // Act
            Action act = () => _testUser.UserName = invalidUserName;

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("User name must be between 3 and 20 characters long", exception.Message);
        }

        [TestMethod]
        public void UserNameNullOrEmptyThrowsException()
        {
            // Arrange

            String invalidUserName = String.Empty;

            // Act
            Action act = () => _testUser.UserName = invalidUserName;

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("User name must be between 3 and 20 characters long", exception.Message);
        }

        [TestMethod]
        public void TestValidPassword()
        {
            // Arrange
            String validPassword = "Abc123";

            // Act
            _testUser.Password = validPassword;

            // Assert
            Assert.AreEqual(validPassword, _testUser.Password);

        }

        [TestMethod]

        public void NullPasswordThrowsException()
        {
            //arrange
            _testPassword = string.Empty;

            //act
            Action act = () => _testUser.Password = _testPassword;

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("Password must be between 5 and 25 characters long", exception.Message);
        }

        [TestMethod]
        public void PasswordTooShortThrowsException()
        {
            // Arrange

            String invalidPassword = "Abc1";

            // Act
            Action act = () => _testUser.Password = invalidPassword;

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("Password must be between 5 and 25 characters long", exception.Message);

        }

        [TestMethod]
        public void PasswordTooLongThrowsException()
        {
            // Arrange
            String invalidPassword = "Abcdefghijklmnopqrstuvwxyz";

            // Act
            Action act = () => _testUser.Password = invalidPassword;

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("Password must be between 5 and 25 characters long", exception.Message);
        }

        [TestMethod]
        public void PasswordNoUpperCaseThrowsException()
        {
            // Arrange
            var user = new User();
            var invalidPassword = "abc123";

            // Act
            Action act = () => user.Password = invalidPassword;

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("Password must contain at least one upper case character", exception.Message);
        }

        [TestMethod]
        public void PasswordNoDigitThrowsException()
        {
            // Arrange
            string invalidPassword = "Password";

            // Act
            Action act = () => _testUser.Password = invalidPassword;

            // Assert

            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("Password must contain at least one numerical digit", exception.Message);
        }

        [TestMethod]
        public void ContainsUser_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            memoryUserRepository.AddUser(_testUser);
            string name = _testUser.UserName;

            // Act
            var actual = memoryUserRepository.ContainsUser(name);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_UserWithSameUserName_ReturnsTrue()
        {
            // Arrange
            User user1 = new User()
            {
                UserName = "username",
                Password = "Password1"
            };
            User user2 = new User()
            {
                UserName = "username",
                Password = "Password2"
            };

            // Act
            bool result = user1.Equals(user2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_UserWithDifferentUserName_ReturnsFalse()
        {
            // Arrange
            User user1 = new User()
            {
                UserName = "username1",
                Password = "Password1"
            };
            User user2 = new User()
            {
                UserName = "username2",
                Password = "Password2"
            };

            // Act
            bool result = user1.Equals(user2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsUser_ReturnsFalse_WhenUserDoesNotExist()
        {
            // Arrange
            memoryUserRepository.AddUser(_testUser);

            // Act
            var actual = memoryUserRepository.ContainsUser("another name");

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AddUser_AddsNewUser_WhenUserDoesNotExist()
        {
            // Arrange
            User newUser = new User()
            {
                UserName = _testUserName,
                Password = _testPassword
            };

            // Act
            memoryUserRepository.AddUser(newUser);

            // Assert
            Assert.IsTrue(memoryUserRepository.ContainsUser(_testUserName));
        }

        [TestMethod]
        public void AddUser_ThrowsBusinessLogicException_WhenUserAlreadyExists()
        {
            // Arrange

            memoryUserRepository.AddUser(_testUser);
            var newUser = new User()
            {
                UserName = _testUserName,
                Password = _testPassword
            };

            // Act & Assert
            Assert.ThrowsException<BusinessLogicException>(() => memoryUserRepository.AddUser(newUser));
        }

        [TestMethod]
        public void GetUser_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var newUser = new User()
            {
                UserName = _testUserName,
                Password = _testPassword
            };
            memoryUserRepository.AddUser(newUser);

            // Act
            var actual = memoryUserRepository.GetUser(_testUserName);

            // Assert
            Assert.AreEqual(newUser, actual);
        }

        [TestMethod]
        public void GetUser_ThrowsBusinessLogicException_WhenUserDoesNotExist()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<BusinessLogicException>(() => memoryUserRepository.GetUser(_testUserName));
        }

        [TestMethod]
        public void CheckUsernameAndPasswordCombination_ReturnsTrue_WhenCombinationExists()
        {
            // Arrange
            memoryUserRepository.AddUser(_testUser);

            // Act
            bool actual = memoryUserRepository.CheckUsernameAndPasswordCombination(_testUser.UserName, _testUser.Password);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckUsernameAndPasswordCombination_ReturnsFalse_WhenCombinationDoesNotExist()
        {
            // Arrange
            memoryUserRepository.AddUser(_testUser);

            // Act
            var actual = memoryUserRepository.CheckUsernameAndPasswordCombination(_testUser.UserName, "password2");

            // Assert
            Assert.IsFalse(actual);
        }

    }

}

