using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameIsOver = false;

    public delegate void ChangeSceneEventHandler();
    public static event ChangeSceneEventHandler OnChangeScene;

    public void ChangeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (currentSceneIndex == lastSceneIndex - 1)
        {
            // Eğer mevcut sahne son sahnenin bir öncesi ise (sondan bir önceki sahne)
            gameIsOver = true;
            SceneManager.LoadScene("GameOver");
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
        }
        else if (currentSceneIndex < lastSceneIndex - 1)
        {
            // Eğer mevcut sahne son sahne değilse, bir sonraki sahneye geç
            int nextSceneIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("Hatalı sahne index'i!"); // Bu durumda bir hata varsa konsola hata mesajı yazdır
        }

        OnChangeScene?.Invoke();
    }
}
