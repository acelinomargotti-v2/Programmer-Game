using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCreatureBehavior : CreatureBehavior // Inheritance.
{
    public float healAmount = 50f;

    // Polymorphism.
    // Overriding the interaction behavior.
    protected override void InteractWithPlayer(PlayerHealth player)
    {
        player.Heal(healAmount);
        Debug.Log($"GoodCreature curou o jogador em {healAmount} de vida.");
    }
}
