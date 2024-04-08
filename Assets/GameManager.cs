using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameIsOver = false;
    public void GameOver()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            SceneManager.LoadScene("GameOver");
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
        }
    }
}
