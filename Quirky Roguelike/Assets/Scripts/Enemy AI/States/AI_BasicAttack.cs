using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BasicAttack : BaseState
{
    StateInitialization ai;
    AiStats stats;
    PlayerStats playerStats;
    Rigidbody2D rb;

    float attackDelay = 0;
    bool attackDelaySet = false;
    float attackTimer = 0;

    void Attack(bool dealDmg)
    {
        if (playerStats == null)
            playerStats = stats.Target.GetComponent<PlayerStats>();

        attackDelay = 0;
        attackDelaySet = false;
        attackTimer = Time.time + stats.AttackCooldown;

        Vector2 dir = (stats.Target.position - ai.transform.position).normalized * stats.AttackKnockback;

        if (dealDmg)
        {
            playerStats.ChangeHpBy();
            playerStats.IsStunned = true;
            stats.TargetRb.AddForce(dir * stats.AttackKnockback);
        }
    }

    public AI_BasicAttack(StateInitialization ai) : base(ai.gameObject)
    {
        this.ai = ai;
        rb = ai.GetComponent<Rigidbody2D>();
        stats = ai.GetComponent<AiStats>();
    }

    public override Type Tick()
    {
        if (Vector2.Distance(ai.transform.position, stats.Target.position) > stats.AttackDistance && attackDelaySet == false)
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
                bool dealDmg = true;

                if (Vector2.Distance(ai.transform.position, stats.Target.position) > stats.AttackDistance)
                    dealDmg = false;

                Attack(dealDmg);

                //stats.AnimState = AnimationState.Attack;
            }
        }

        return typeof(AI_BasicAttack);
    }

}
