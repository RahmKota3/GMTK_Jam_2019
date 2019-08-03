using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AiStats : EntityStats
{
    public Transform Target;

    public float AttackDistance = 2;
    public float AttackCooldown = 0.75f;
    public float AttackDelay = 0.5f;

    public float MovementSpeed = 0.25f;

    public Type AttackType { get; private set; }

    protected override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }

    protected override void Awake()
    {
        base.Awake();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        AttackType = typeof(AI_BasicAttack);
        OnEntityDeath += Die;
        CurrentHp = MaxHp;
    }
}
