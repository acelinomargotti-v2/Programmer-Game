using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health Settings")]
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Player tomou {damageAmount} de dano. Vida atual: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Player foi curado em {healAmount}. Vida atual: {currentHealth}");
    }


    private void Die()
    {
        Debug.Log("Player morreu!");
        // Add death logic here (restart game, game over screen, etc.).
    }

    // Method to return the player's current health (optional).
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
