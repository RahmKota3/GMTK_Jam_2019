using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    public float MaxSpeed = 8;

    public float ShootingQuirkKnockback = 100;

    public void SetHealth(int amount)
    {
        CurrentHp = amount;
        if (OnHpChanged != null)
            OnHpChanged.Invoke();
    }

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
