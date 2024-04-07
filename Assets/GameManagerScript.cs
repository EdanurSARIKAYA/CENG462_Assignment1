using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    private bool gameIsOver = false;

    void Update()
    {
        // Eğer oyun bitti ise (gameIsOver true olduysa), oyuncunun hareketini engelle
        if (gameIsOver)
        {
            // GetComponent ile PlayerMovement scriptine erişerek, bu script içindeki hareketi devre dışı bırak
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            Player2Movement player2Movement = FindObjectOfType<Player2Movement>();
            if (playerMovement != null && player2Movement != null)
            {
                playerMovement.enabled = false; // PlayerMovement scriptini devre dışı bırak
                player2Movement.enabled = false; // Player2Movement scriptini devre dışı bırak
            }
        }
    }

    public void GameOver()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
        }
    }
}
