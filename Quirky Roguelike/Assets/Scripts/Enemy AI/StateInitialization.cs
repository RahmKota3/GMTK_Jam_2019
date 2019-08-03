using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StateInitialization : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }

    void InitializeStateMachine()
    {
        Pathfinding pathf = FindObjectOfType<Pathfinding>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(AI_BasicAttack), new AI_BasicAttack(ai: this) },
            { typeof(AI_BasicMovement), new AI_BasicMovement(ai: this, pathfinding: pathf) },
        };

        StateMachine.SetStates(states);
    }

    private void Awake()
    {
        StateMachine = GetComponent<StateMachine>();
        InitializeStateMachine();
    }
}
