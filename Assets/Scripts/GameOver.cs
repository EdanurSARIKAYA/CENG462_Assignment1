using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void restartGame()
    {
        Debug.Log("Restart Game Button Clicked");
        SceneManager.LoadScene("Level1");
    }

    public void mainMenu()
    {
        Debug.Log("Main Menu Button Clicked");
        SceneManager.LoadScene("Start");
    }

    public void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol tıklandığında
        {
            Debug.Log("Mouse Clicked at Position: " + Input.mousePosition);
        }
    }
}
