using BusinessLogic.DomainObjects;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Controllers;
using Services;

namespace EntityFrameworkTests
{
    [TestClass]
    public class EFUserRepositoryTests
    {
        EFSphereRepository eFSphereRepository;
        EFUserRepository eFUserRepository;
        EFMaterialRepository eFMaterialRepository;
        EFModelRepository eFModelRepository;
        EFSceneRepository eFSceneRepository;

        SphereManagementService sphereManagementService;
        MaterialManagementService materialManagementService;
        ModelManagementService modelManagementService;
        SceneManagementService sceneManagementService;
        UserService userService;
        EditSceneService editSceneService;
        RenderingService renderingService;

        SphereManagementController sphereManagementController;
        MaterialManagementController materialManagementController;
        ModelManagementController modelManagementController;
        SceneManagementController sceneController;
        UserController userController;
        EditSceneController editSceneController;

        Context context;

        [TestInitialize]
        public void TestInitialize()
        {
            eFSphereRepository = new EFSphereRepository();
            eFUserRepository = new EFUserRepository();
            eFMaterialRepository = new EFMaterialRepository();
            eFModelRepository = new EFModelRepository();
            eFSceneRepository = new EFSceneRepository();

            sphereManagementService = new SphereManagementService(eFSphereRepository);
            materialManagementService = new MaterialManagementService(eFMaterialRepository);
            modelManagementService = new ModelManagementService(eFModelRepository, eFSceneRepository);
            sceneManagementService = new SceneManagementService(eFSceneRepository);
            userService = new UserService(eFUserRepository);
            editSceneService = new EditSceneService(eFSceneRepository);
            renderingService = new RenderingService();

            sphereManagementController = new SphereManagementController(sphereManagementService, modelManagementService);
            materialManagementController = new MaterialManagementController(materialManagementService, modelManagementService);
            modelManagementController = new ModelManagementController();
            modelManagementController.SphereService = sphereManagementService;
            modelManagementController.ModelService = modelManagementService;
            modelManagementController.MaterialService = materialManagementService;
            modelManagementController.RenderingService = renderingService;
            sceneController = new SceneManagementController(sceneManagementService);
            userController = new UserController(userService);
            editSceneController = new EditSceneController();

            context = new Context();
            context.SphereController = sphereManagementController;
            context.MaterialController = materialManagementController;
            context.ModelController = modelManagementController;
            context.SceneController = sceneController;
            context.UserController = userController;
            context.EditSceneController = editSceneController;

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

            context.UserController.SignUp("TestUser", "Password1");

            bool containsUser = eFUserRepository.ContainsUser("TestUser");
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

            User retrievedUser = eFUserRepository.GetUser("TestUser");

            bool logged = context.UserController.Login("TestUser", "Password1");

            Assert.IsTrue(logged);
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

            bool containsUser = eFUserRepository.ContainsUser("TestUser");

            Assert.IsTrue(containsUser);
        }

        [TestMethod]
        public void ContainsUser_NonexistentUser_ReturnsFalse()
        {
            bool containsUser = eFUserRepository.ContainsUser("NonexistentUser");

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

            bool isValid = eFUserRepository.CheckUsernameAndPasswordCombination("TestUser", "Password1");
            bool isValid2 = userController.Login("TestUser", "Password1");


            Assert.IsTrue(isValid);
            Assert.IsTrue(isValid2);

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

            bool isValid2 = userController.Login("TestUser", "WrongPassword");
            bool isValid = eFUserRepository.CheckUsernameAndPasswordCombination("TestUser", "WrongPassword");
            

            Assert.IsFalse(isValid);
            Assert.IsFalse(isValid2);
        }
    }

}
