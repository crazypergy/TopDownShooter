using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Max health points
    public int currentHealth; // Current health

    void Start()
    {
        currentHealth = maxHealth; // Start at full health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over - Player Destroyed!");
            // Add game over logic here later
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // Lose 1 health on enemy collision
            Destroy(collision.gameObject); // Destroy the enemy
        }
    }
}