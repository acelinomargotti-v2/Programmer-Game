using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehavior : MonoBehaviour
{
    public float moveRadius = 5f; // Raio máximo de movimentação
    public float moveSpeed = 2f;  // Velocidade do NPC
    public float waitTime = 2f;   // Tempo de espera entre movimentos

    private Vector3 targetPosition; // Próxima posição
    private bool isMoving = false;
    private float waitTimer = 0f;

    void Start()
    {
        // Define o primeiro alvo aleatório
        SetRandomTarget();
    }

    void Update()
    {
        HandleRandomMovement(); // Método para gerenciar a movimentação
    }

    // Método principal para gerenciar movimentação aleatória
    void HandleRandomMovement()
    {
        if (isMoving)
        {
            MoveToTarget();
        }
        else
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                waitTimer = 0f;
                SetRandomTarget(); // Escolhe um novo destino
            }
        }
    }

    // Define uma nova posição aleatória dentro do raio
    void SetRandomTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection.y = 0; // Mantém o NPC no plano (2D ou terreno)
        targetPosition = transform.position + randomDirection;

        isMoving = true; // Começa a se mover
    }

    // Movimenta o NPC em direção ao alvo
    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false; // Para de se mover ao atingir o alvo
        }
    }

    // Visualiza o raio no editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, moveRadius);
    }
}
