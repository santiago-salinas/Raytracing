using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
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
        public void Initialize() {

            testUserName = "TestUsername";
            testPassword = "Abc123";
            testUser = new User();
            DateTimeProvider.Reset();
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

        }

    }

}

