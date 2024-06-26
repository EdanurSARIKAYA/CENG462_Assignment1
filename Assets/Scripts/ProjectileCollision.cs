using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public int damageAmount = 20; // Projectile'ın verdiği hasar miktarı
    private ScoreManager scoreManager;
    private int wallCollisionCount = 0; // Counter for wall collisions

    public delegate void CollisionEventHandler();
    public static event CollisionEventHandler OnCollision;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Scene'deki ScoreManager'ı bul
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nesne player'a veya zemine çarptığında yok olur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncuya zarar ver
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            HealthBar healthBar = playerHealth.healthBar;
            if (playerHealth != null && healthBar != null)
            {
                playerHealth.TakeDamage(damageAmount);
                if (scoreManager != null)
                {
                    scoreManager.enemyScore++; // Player score'u artır
                    scoreManager.UpdateScoreText(); // Score'u güncelle
                }
            }

            Destroy(gameObject);
            OnCollision?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // İkinci oyuncuya zarar ver
            PlayerHealth2 playerHealth2 = collision.gameObject.GetComponent<PlayerHealth2>();
            HealthBar healthBar2 = playerHealth2.healthBar;
            if (playerHealth2 != null && healthBar2 != null)
            {
                playerHealth2.TakeDamage(damageAmount);
                if (scoreManager != null)
                {
                    scoreManager.playerScore++; // Enemy score'u artır
                    scoreManager.UpdateScoreText(); // Score'u güncelle
                }
            }

            Destroy(gameObject);
            OnCollision?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // Zeminle çarpıştığında yok ol
            Destroy(gameObject);
            OnCollision?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // Increment wall collision count
            wallCollisionCount++;

            // If this is the second collision with a wall, destroy the projectile
            if (wallCollisionCount >= 2)
            {
                Destroy(gameObject);
                OnCollision?.Invoke();
            }
        }
    }
}
