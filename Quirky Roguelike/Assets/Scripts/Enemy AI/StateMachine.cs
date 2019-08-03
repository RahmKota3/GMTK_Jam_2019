using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    Dictionary<Type, BaseState> availableStates;

    public BaseState CurrentState { get; private set; }

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        availableStates = states;
    }

    private void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = availableStates[typeof(AI_BasicMovement)];
        }

        var nextState = CurrentState.Tick();

        if (nextState != null && nextState != CurrentState.GetType())
        {
            SwitchToNewState(nextState);
        }
    }

    void SwitchToNewState(Type nextState)
    {
        CurrentState = availableStates[nextState];
    }
}
