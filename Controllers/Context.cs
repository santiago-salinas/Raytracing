
namespace Controllers
{
    public class Context
    {
        public Context() { }
        public SphereManagementController SphereController { get; set; }
        public MaterialManagementController MaterialController { get; set; }
        public ModelManagementController ModelController { get; set; }
        public UserController UserController { get; set; }
        public SceneManagementController SceneController { get; set; }
        public EditSceneController EditSceneController { get; set; }
        public string CurrentUser { get; set; }
    }
}
