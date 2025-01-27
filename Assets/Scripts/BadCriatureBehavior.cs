using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCreatureBehavior : CreatureBehavior // Inheritance.
{
    public float damageAmount = 50f;

    // Polymorphism.
    // Overriding interaction behavior.
    protected override void InteractWithPlayer(PlayerHealth player)
    {
        player.TakeDamage(damageAmount);
        Debug.Log($"BadCreature causou {damageAmount} de dano ao jogador.");
    }
}
