using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health Settings")]
    public float maxHealth = 100f; // Vida m�xima do jogador
    private float currentHealth;   // Vida atual do jogador

    void Start()
    {
        // Define a vida atual como o valor m�ximo no in�cio
        currentHealth = maxHealth;
    }

    // M�todo para o jogador receber dano
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Garante que a vida fique entre 0 e o m�ximo

        Debug.Log($"Player tomou {damageAmount} de dano. Vida atual: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�todo para curar o jogador
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Garante que a vida n�o ultrapasse o m�ximo

        Debug.Log($"Player foi curado em {healAmount}. Vida atual: {currentHealth}");
    }

    // M�todo chamado quando a vida do jogador chega a 0
    private void Die()
    {
        Debug.Log("Player morreu!");
        // Adicione l�gica de morte aqui (reiniciar jogo, tela de game over, etc.)
    }

    // M�todo para retornar a vida atual do jogador (opcional)
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
