using Controllers;
using DataAccess;
using DataAccess.Repositories;
using Services;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            EFSphereRepository eFSphereRepository = new EFSphereRepository();
            EFUserRepository eFUserRepository = new EFUserRepository();
            EFMaterialRepository eFMaterialRepository = new EFMaterialRepository();
            EFModelRepository eFModelRepository = new EFModelRepository();
            EFSceneRepository eFSceneRepository = new EFSceneRepository();

            SphereManagementService sphereManagementService = new SphereManagementService(eFSphereRepository);
            MaterialManagementService materialManagementService = new MaterialManagementService(eFMaterialRepository);
            ModelManagementService modelManagementService = new ModelManagementService(eFModelRepository, eFSceneRepository);
            SceneManagementService sceneManagementService = new SceneManagementService(eFSceneRepository);
            UserService userService = new UserService(eFUserRepository);
            EditSceneService editSceneService = new EditSceneService(eFSceneRepository);
            RenderingService renderingService = new RenderingService();

            SphereManagementController sphereManagementController = new SphereManagementController(sphereManagementService, modelManagementService);
            MaterialManagementController materialManagementController = new MaterialManagementController(materialManagementService, modelManagementService);
            ModelManagementController modelManagementController = new ModelManagementController();
            modelManagementController.SphereService = sphereManagementService;
            modelManagementController.ModelService = modelManagementService;
            modelManagementController.MaterialService = materialManagementService;
            modelManagementController.RenderingService = renderingService;
            SceneManagementController sceneController = new SceneManagementController(sceneManagementService);
            UserController userController = new UserController(userService);
            EditSceneController editSceneController = new EditSceneController();
            editSceneController.ModelManagementService = modelManagementService;
            editSceneController.EditSceneService = editSceneService;
            editSceneController.RenderingService = renderingService;
            editSceneController.SceneManagementService = sceneManagementService;

            Context context = new Context();
            context.SphereController = sphereManagementController;
            context.MaterialController = materialManagementController;
            context.ModelController = modelManagementController;
            context.SceneController = sceneController;
            context.UserController = userController;
            context.EditSceneController = editSceneController;

            Application.Run(new LogInPage(context));

            Application.Exit();
        }

        static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is SqlException)
            {
                MessageBox.Show("An error ocurred when trying to connect with the database. The application will now close.", "Connection Error");
                Application.Exit();
            }
        }
    }
}
