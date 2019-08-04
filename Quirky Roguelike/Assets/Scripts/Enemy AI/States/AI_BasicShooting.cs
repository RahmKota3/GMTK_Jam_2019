using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BasicShooting : BaseState
{
    StateInitialization ai;
    AiStats stats;
    PlayerStats playerStats;
    Rigidbody2D rb;

    float attackDelay = 0;
    bool attackDelaySet = false;
    float attackTimer = 0;

    void Attack()
    {
        if (playerStats == null)
            playerStats = stats.Target.GetComponent<PlayerStats>();

        attackDelay = 0;
        attackDelaySet = false;
        attackTimer = Time.time + stats.AttackCooldown;
        
        SimplePool.Spawn(stats.Projectile, stats.Barrel.position, stats.Barrel.rotation);
    }

    public AI_BasicShooting(StateInitialization ai) : base(ai.gameObject)
    {
        this.ai = ai;
        rb = ai.GetComponent<Rigidbody2D>();
        stats = ai.GetComponent<AiStats>();
    }

    public override Type Tick()
    {
        if (Vector2.Distance(ai.transform.position, stats.Target.position) > stats.AttackDistance && attackDelaySet == false)
            return stats.MovementType;

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.5f, stats.Target.position - transform.position, 50, stats.RaycastLayers);

        if (hit == false || hit.collider.gameObject.tag != "Player")
            return stats.MovementType;

        if (Time.time > attackTimer)
        {
            if (attackDelaySet == false)
            {
                attackDelay = Time.time + stats.AttackDelay;
                attackDelaySet = true;
            }
            else if (Time.time > attackDelay)
            {
                Vector2 dir = (stats.Target.position - transform.position).normalized;
                stats.Barrel.transform.right = dir;

                Attack();

                //stats.AnimState = AnimationState.Attack;
            }
        }

        return stats.AttackType;
    }

}