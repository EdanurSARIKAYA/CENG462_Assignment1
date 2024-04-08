using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool isDead;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            // Player has no health left, trigger game over
            isDead = true;
            gameManager.GameOver(); // only call once
            Debug.Log("Dead");
        }
    }

   
}
