using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
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
