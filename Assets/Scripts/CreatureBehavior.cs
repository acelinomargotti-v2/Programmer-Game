using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehavior : MonoBehaviour
{
    public float moveRadius = 5f;
    public float moveSpeed = 2f;
    public float waitTime = 2f;

    private Vector3 targetPosition;
    private bool isMoving = false;
    private float waitTimer = 0f;

    void Start()
    {
        SetRandomTarget();
    }

    void Update()
    {
        HandleRandomMovement();
    }


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
                SetRandomTarget();
            }
        }
    }


    void SetRandomTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection.y = 0;
        targetPosition = transform.position + randomDirection;

        isMoving = true;
    }


    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, moveRadius);
    }

    // Method to interact with the player (virtual to be overridden).
    protected virtual void InteractWithPlayer(PlayerHealth player)
    {
        // By default, it does nothing. Subclasses define the behavior.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                InteractWithPlayer(player); // Calling the polymorphic method.
            }
        }
    }
}
