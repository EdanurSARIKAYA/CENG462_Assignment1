using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text totalScoreText;
    public int playerScore = 0;
    public int enemyScore = 0;
    public int totalPlayerScore = 0; // Toplam oyuncu skoru
    public int totalEnemyScore = 0; // Toplam düşman skoru

    public void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString() + " - " + enemyScore.ToString();
    }

    public void UpdateTotalScore()
    {
        totalPlayerScore += playerScore;
        PlayerPrefs.SetInt("TotalPlayerScore", totalPlayerScore);
        totalEnemyScore += enemyScore;
        PlayerPrefs.SetInt("TotalEnemyScore", totalEnemyScore);
    }

    public void UpdateTotalScoreText()
    {
        int savedPlayerScore = PlayerPrefs.GetInt("TotalPlayerScore", 0);
        int savedEnemyScore = PlayerPrefs.GetInt("TotalEnemyScore", 0);
        Debug.LogError(savedPlayerScore.ToString() + " - " + savedEnemyScore.ToString());
        totalScoreText.text = savedPlayerScore.ToString() + " - " + savedEnemyScore.ToString();
    }
}
