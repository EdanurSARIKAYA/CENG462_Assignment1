using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void settingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
