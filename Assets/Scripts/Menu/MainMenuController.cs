using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClassicGames.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        public void LoadPhysicsBall()
        {
            Debug.Log("Button: PhysicsBall is starting");
            SceneManager.LoadScene("PhysicsBall");
        }

        public void ExitApplication()
        {
            Debug.Log("Exit the application");
            Application.Quit();
        }
    }
}
