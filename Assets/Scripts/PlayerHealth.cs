using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float _maxHealth = 100f; // Real private field of the property.
    private float currentHealth;

    // Property for maxHealth encapsulation.
    public float MaxHealth
    {
        get { return _maxHealth; }
        set
        {
            if (value > 0 && value < 101)
            {
                _maxHealth = value;
                currentHealth = Mathf.Clamp(currentHealth, 0, _maxHealth);
            }
            else
            {
                Debug.LogError("O valor de MaxHealth deve ser maior que zero.");
            }
        }
    }

    void Start()
    {
        currentHealth = MaxHealth; // Property instead of the field.
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);

        Debug.Log($"Player tomou {damageAmount} de dano. Vida atual: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);

        Debug.Log($"Player foi curado em {healAmount}. Vida atual: {currentHealth}");
    }

    private void Die()
    {
        Debug.Log("Player morreu!");
        // Add death logic here (restart game, game over screen, etc.).
    }

    // Optional method to get the player's current health.
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
