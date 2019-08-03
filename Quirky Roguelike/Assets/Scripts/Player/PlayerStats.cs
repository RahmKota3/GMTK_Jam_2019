using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    public float MaxSpeed = 8;

    public float ShootingQuirkKnockback = 100;

    protected override void Die()
    {
        base.Die();

        // TODO: Respawn.
    }

    protected override void Awake()
    {
        base.Awake();
        OnEntityDeath += Die;
    }
}
