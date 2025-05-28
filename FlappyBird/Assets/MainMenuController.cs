using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
