using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public int MaxHp = 3;
    [HideInInspector]
    public int CurrentHp = 1;

    public Action OnEntityDeath;
    public Action OnHpChanged;

    public void ChangeHpBy(int amount = -1)
    {
        CurrentHp += amount;

        if (OnHpChanged != null)
            OnHpChanged.Invoke();

        if (CurrentHp <= 0)
            OnEntityDeath.Invoke();
    }

    protected virtual void Die() { }

    protected virtual void Awake()
    {
        CurrentHp = MaxHp;
    }
}
