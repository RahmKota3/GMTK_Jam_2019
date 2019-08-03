using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BasicMovement : BaseState
{
    StateInitialization ai;

    List<Vector2> path;

    Pathfinding pathfinding;
    AiStats stats;

    Rigidbody2D rb;

    void MoveTowardsTarget()
    {
        if (path.Count == 0)
        {
            Debug.Log("no path");
            return;
        }

        Vector2 dir = path[0] - (Vector2)transform.position;

        if (rb.velocity.magnitude < stats.MovementSpeed && stats.IsStunned == false)
            rb.velocity += dir.normalized * stats.MovementSpeed;

        if (Vector2.Distance(transform.position, path[0]) <= 0.5f)
        {
            path.RemoveAt(0);
        }

        if (path.Count == 0)
            rb.velocity = Vector2.zero;
    }

    bool CheckIfNodeExists(Vector2 pos)
    {
        return pathfinding.NodeExists(pos);
    }

    List<Vector2> GetPath(Vector2 targetPoint)
    {
        path.Clear();
        return pathfinding.GetPath(transform.position, targetPoint);
    }

    public AI_BasicMovement(StateInitialization ai, Pathfinding pathfinding) : base(ai.gameObject)
    {
        this.ai = ai;
        stats = ai.GetComponent<AiStats>();
        rb = ai.GetComponent<Rigidbody2D>();
        this.pathfinding = pathfinding;

        path = new List<Vector2>();
    }

    public override Type Tick()
    {
        if (Vector2.Distance(ai.transform.position, stats.Target.position) <= stats.AttackDistance)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.5f, stats.Target.position - transform.position, 50, stats.RaycastLayers);
            
            if ((stats.Attack == AttackTypes.Basic) || (stats.Attack == AttackTypes.BasicShooting && hit &&
                hit.collider.gameObject.tag == "Player"))
            {
                return stats.AttackType;
            }
        }

        if (CheckIfNodeExists(stats.Target.position))
        {
            path = GetPath(stats.Target.position);

            if(path != null && path.Count > 0)
                MoveTowardsTarget();
        }

        //stats.AnimState = AnimationState.Walk;

        return typeof(AI_BasicMovement);
    }

}
