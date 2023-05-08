using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class UserTests
    {
        private User testUser;
        private String testUserName;
        private String testPassword;

        [TestInitialize]
        public void Initialize()
        {

            testUserName = "TestUsername";
            testPassword = "Abc123";
            testUser = new User()
            {
                UserName= testUserName,
                Password= testPassword
            };
            DateTimeProvider.Reset();
        }

        [TestCleanup]
        public void Cleanup()
        {
            UserCollection.DropCollection();
        }

        [TestMethod]
        public void CreatedValidUser()
        {
            // Arrange
            testUserName = "TestUsername";
            testPassword = "Abc123";

            // Act
            testUser = new User()
            {
                UserName = testUserName,
                Password = testPassword,
                RegisterDate = DateTimeProvider.Now
            };

            // Assert
            Assert.IsNotNull(testUserName);

        }

        [TestMethod]
        public void RegistrationDateIsCorrect()
        {
            testUser = new User()
            {
                UserName = testUserName,
                Password = testPassword,
                RegisterDate = DateTimeProvider.Now
            };

            Assert.AreEqual(DateTimeProvider.Now, testUser.RegisterDate);

        }


        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + testUserName;
            //act
            testUser.UserName = nameWithLeftPadding;
            //assert
            Assert.AreEqual(testUser.UserName, testUserName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = testUserName + " ";
            //act
            testUser.UserName = nameWithRightPadding;
            //assert
            Assert.AreEqual(testUser.UserName, testUserName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + testUserName + " ";
            //act
            testUser.UserName = nameWithPaddings;
            //assert
            Assert.AreEqual(testUser.UserName, testUserName);
        }

        [TestMethod]
        public void CheckIfUserNameIsValid_UserNameContainsSpace_ArgumentExceptionThrown()
        {
            // Arrange
            string invalidUserName = "user name with space";

            // Act
            Action act = () => testUser.UserName = invalidUserName;
            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual("User name cannot contain spaces", exception.Message);
        }

        [TestMethod]
        public void UserNameTooShortThrowsException()
        {
            // Arrange
            String invalidUserName = "aA";

            // Act
            Action act = () => testUser.UserName = invalidUserName;

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual("User name must be between 3 and 20 characters long", exception.Message);

        }

        [TestMethod]
        public void UserNameTooLongThrowsException()
        {
            // Arrange
            String invalidUserName = "abcdefghijklmnopqrstuvwxyz";

            // Act
            Action act = () => testUser.UserName = invalidUserName;

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual("User name must be between 3 and 20 characters long", exception.Message);
        }

        [TestMethod]
        public void UserNameNullOrEmptyThrowsException()
        {
            // Arrange

            String invalidUserName = String.Empty;

            // Act
            Action act = () => testUser.UserName = invalidUserName;

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual("User name must be between 3 and 20 characters long", exception.Message);
        }

        [TestMethod]
        public void TestValidPassword()
        {
            // Arrange
            String validPassword = "Abc123";

            // Act
            testUser.Password = validPassword;

            // Assert
            Assert.AreEqual(validPassword, testUser.Password);

        }

        [TestMethod]

        public void NullPasswordThrowsException()
        {
            //arrange
            testPassword = string.Empty;

            //act
            Action act = () => testUser.Password = testPassword;

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual("Password must be between 5 and 25 characters long", exception.Message);
        }

        [TestMethod]
        public void PasswordTooShortThrowsException()
        {
            // Arrange

            String invalidPassword = "Abc1";

            // Act
            Action act = () => testUser.Password = invalidPassword;

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual("Password must be between 5 and 25 characters long", exception.Message);

        }

        [TestMethod]
        public void PasswordTooLongThrowsException()
        {
            // Arrange
            String invalidPassword = "Abcdefghijklmnopqrstuvwxyz";

            // Act
            Action act = () => testUser.Password = invalidPassword;

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(act);
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
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual("Password must contain at least one upper case character", exception.Message);
        }

        [TestMethod]
        public void PasswordNoDigitThrowsException()
        {
            // Arrange
            string invalidPassword = "Password";

            // Act
            Action act = () => testUser.Password = invalidPassword;

            // Assert
            
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual("Password must contain at least one numerical digit", exception.Message);
        }

        [TestMethod]
        public void ContainsUser_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            UserCollection.AddUser(testUser);
            string name = testUser.UserName;

            // Act
            var actual = UserCollection.ContainsUser(name);

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
                Password= "Password1"
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
            UserCollection.AddUser(testUser);

            // Act
            var actual = UserCollection.ContainsUser("another name");

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AddUser_AddsNewUser_WhenUserDoesNotExist()
        {
            // Arrange
            User newUser = new User()
            {
                UserName = testUserName,
                Password = testPassword
            };

            // Act
            UserCollection.AddUser(newUser);

            // Assert
            Assert.IsTrue(UserCollection.ContainsUser(testUserName));
        }

        [TestMethod]
        public void AddUser_ThrowsBusinessLogicException_WhenUserAlreadyExists()
        {
            // Arrange

            UserCollection.AddUser(testUser);
            var newUser = new User()
            {
                UserName = testUserName,
                Password = testPassword
            }; 

            // Act & Assert
            Assert.ThrowsException<BusinessLogicException>(() => UserCollection.AddUser(newUser));
        }

        [TestMethod]
        public void GetUser_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var newUser = new User()
            {
                UserName = testUserName,
                Password = testPassword
            };
            UserCollection.AddUser(newUser);

            // Act
            var actual = UserCollection.GetUser(testUserName);

            // Assert
            Assert.AreEqual(newUser, actual);
        }

        [TestMethod]
        public void GetUser_ThrowsBusinessLogicException_WhenUserDoesNotExist()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<BusinessLogicException>(() => UserCollection.GetUser(testUserName));
        }

        [TestMethod]
        public void CheckUsernameAndPasswordCombination_ReturnsTrue_WhenCombinationExists()
        {
            // Arrange
            UserCollection.AddUser(testUser);

            // Act
            bool actual = UserCollection.CheckUsernameAndPasswordCombination(testUser.UserName, testUser.Password);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckUsernameAndPasswordCombination_ReturnsFalse_WhenCombinationDoesNotExist()
        {
            // Arrange
            UserCollection.AddUser(testUser);

            // Act
            var actual = UserCollection.CheckUsernameAndPasswordCombination(testUser.UserName, "password2");

            // Assert
            Assert.IsFalse(actual);
        }

    }

}

