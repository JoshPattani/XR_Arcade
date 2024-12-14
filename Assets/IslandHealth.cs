using UnityEngine;

public class IslandHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the island
    private int currentHealth;

    public Transform healthBar; // Assign the health bar child object in the Inspector

    private float initialHealthBarZScale; // Stores the original Z scale of the health bar

    private void Start()
    {
        currentHealth = maxHealth; // Initialize island health

        // Save the initial Z scale of the health bar
        if (healthBar != null)
        {
            initialHealthBarZScale = healthBar.localScale.z;
        }

        // Update health bar based on current health
        UpdateHealthBar();
    }

    private void OnTriggerEnter(Collider other)
{
    // Check for enemies
    if (other.TryGetComponent(out EnemyHealth enemyHealth))
    {
        // Apply damage equal to enemy's max health
        TakeDamage(enemyHealth.maxHealth);
        Destroy(other.gameObject);
    }
}

private void TakeDamage(int damage)
{
    currentHealth -= damage;
    UpdateHealthBar();

    if (currentHealth <= 0)
    {
        Debug.Log("Island Destroyed!");
        // Add any destruction or game-over logic here
    }
}

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            // Calculate the normalized health (between 0 and 1)
            float healthPercent = (float)currentHealth / maxHealth;

            // Adjust the Z scale proportionally while keeping the initial scale
            Vector3 barScale = healthBar.localScale;
            barScale.z = initialHealthBarZScale * healthPercent;
            healthBar.localScale = barScale;
        }
    }

    private void Die()
    {
        Debug.Log("The island has been destroyed!");
        // Add destruction logic, animations, or game over logic here
    }
}
