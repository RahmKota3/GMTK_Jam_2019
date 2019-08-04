using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum AttackTypes { Basic, BasicShooting }
public enum MovementTypes { Basic }

public class AiStats : EntityStats
{
    public GameObject Projectile;
    public Transform Barrel;

    public LayerMask RaycastLayers;
    
    public AttackTypes Attack;
    public MovementTypes Movement;

    public Transform Target;

    public float AttackDistance = 2;
    public float AttackCooldown = 0.75f;
    public float AttackDelay = 0.5f;
    public float AttackKnockback = 2000;

    public float MovementSpeed = 0.25f;

    public Rigidbody2D TargetRb;

    public Type AttackType { get; private set; }
    public Type MovementType { get; private set; }

    void SetTypes()
    {
        switch (Attack)
        {
            case AttackTypes.Basic:
                AttackType = typeof(AI_BasicAttack);
                break;
            case AttackTypes.BasicShooting:
                AttackType = typeof(AI_BasicShooting);
                break;
        }

        switch (Movement)
        {
            case MovementTypes.Basic:
                MovementType = typeof(AI_BasicMovement);
                break;
        }
    }

    protected override void Die()
    {
        base.Die();

        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    protected override void Awake()
    {
        base.Awake();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        TargetRb = Target.GetComponent<Rigidbody2D>();
        OnEntityDeath += Die;
        CurrentHp = MaxHp;

        SetTypes();
    }
}
