using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 8; // Maximum health
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health
    }

    private void Update()
    {
        int arrowCount = 0;

        // Count the number of arrow children
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Arrow")) // Ensure the arrows are tagged correctly
            {
                arrowCount++;
            }
        }

        // Calculate health based on the number of arrows
        int healthAfterDamage = maxHealth - arrowCount;

        if (healthAfterDamage < currentHealth)
        {
            currentHealth = healthAfterDamage;

            // Check if the enemy is dead
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Add any death effects (e.g., particle effects, sound, animations)
        Debug.Log(gameObject.name + " has been destroyed!");

        // Destroy the enemy object
        Destroy(gameObject);
    }
}
