using System;
using System.Windows.Forms;
using BusinessLogic;

namespace UI
{
    public partial class LogInPage : Form
    {
        public LogInPage()
        {
            InitializeComponent();
            User user1 = new User()
            {
                UserName = "Test",
                Password = "Test1",
                RegisterDate = DateTime.Now,
                
            };

            User user2 = new User()
            {
                UserName = "Test2",
                Password = "Test1",
                RegisterDate = DateTime.Now,
            };

            User user3 = new User()
            {
                UserName = "Test3",
                Password = "Test1",
                RegisterDate = DateTime.Now,
            };
            UserCollection.AddUser(user1);
            UserCollection.AddUser(user2);
            UserCollection.AddUser(user3);


            Sphere sphere1 = new Sphere("Sphere 1", 2.5f,user1);
            Sphere sphere2 = new Sphere("Sphere 2", 3.0f,user2);
            Sphere sphere3 = new Sphere("Sphere 3", 1.8f,user3);

            SphereCollection.AddSphere(sphere1);
            SphereCollection.AddSphere(sphere2);
            SphereCollection.AddSphere(sphere3);

            Color color1 = new Color(0.5,1,0.3);
            Color color2 = new Color(1,0.5,1);
            Color color3 = new Color(0.2, 0.63, 0.16);
            Lambertian lambertian1 = new Lambertian("Lambertian 1", color1,user1);
            Lambertian lambertian2 = new Lambertian("Lambertian 2", color2,user2);
            Lambertian lambertian3 = new Lambertian("Lambertian 3", color3,user1);
            LambertianCollection.AddLambertian(lambertian1);
            LambertianCollection.AddLambertian(lambertian3);
            LambertianCollection.AddLambertian(lambertian2);

            Model model1 = new Model("Model 1",sphere1,lambertian1,user1);
            ModelCollection.AddModel(model1);

            CameraDTO defaultCameraValues = new CameraDTO()
            {
                LookFrom = new Vector(0, 2, 0),
                LookAt = new Vector(0, 2, 5),
                Up = new Vector(0, 1, 0),
                FieldOfView = 30,
                MaxDepth = 50,
                ResolutionX = 650,
                ResolutionY = 375,
                SamplesPerPixel = 50
            };

            Scene scene1 = new Scene()
            {
                Name = "Scene 1",
                LastModificationDate = DateTime.Now,
                LastRenderDate = DateTime.Now,
                Owner = user1,
                CameraDTO = defaultCameraValues,
            };
            SceneCollection.AddScene(scene1);
            scene1.AddPositionedModel(new PositionedModel()
            {
                PositionedModelModel = model1,
                PositionedModelPosition = new Vector(1, 1, 1)
            });
        }


        private void logInButton_Click(object sender, EventArgs e)
        {
            string userNameText = userNameTextBox.Text;
            string passwordText = passwordTextBox.Text;

            bool credentialsAreCorrect = UserCollection.CheckUsernameAndPasswordCombination(userNameText, passwordText);
            
            if (credentialsAreCorrect) {
                User user = UserCollection.GetUser(userNameText);
                new MainPage(user).Show();
                this.Hide();
            }
            else
            {
                logInLabel.Text = "Username and password combination is incorrect";
                userNameTextBox.Clear();
                passwordTextBox.Clear();
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            new SignUpPage().Show();
            this.Hide();
        }

        private void Logo_Click(object sender, EventArgs e)
        {

        }

        private void LogInPage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
