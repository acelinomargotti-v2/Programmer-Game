using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health Settings")]
    public float maxHealth = 100f; // Vida máxima do jogador
    private float currentHealth;   // Vida atual do jogador

    void Start()
    {
        // Define a vida atual como o valor máximo no início
        currentHealth = maxHealth;
    }

    // Método para o jogador receber dano
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Garante que a vida fique entre 0 e o máximo

        Debug.Log($"Player tomou {damageAmount} de dano. Vida atual: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para curar o jogador
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Garante que a vida não ultrapasse o máximo

        Debug.Log($"Player foi curado em {healAmount}. Vida atual: {currentHealth}");
    }

    // Método chamado quando a vida do jogador chega a 0
    private void Die()
    {
        Debug.Log("Player morreu!");
        // Adicione lógica de morte aqui (reiniciar jogo, tela de game over, etc.)
    }

    // Método para retornar a vida atual do jogador (opcional)
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
