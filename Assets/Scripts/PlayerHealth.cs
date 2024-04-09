using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    
    public int maxHealth = 120;
    public int currentHealth;
    public HealthBar healthBar;
    private bool isDead;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            // Player has no health left, trigger game over
            isDead = true;
            gameManager.ChangeScene(); // only call once
            Debug.Log("Dead");
        }
    }

   
}
