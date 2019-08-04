using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public int PlayerHp;

    PlayerStats stats;

    void HpChange()
    {
        PlayerHp = stats.CurrentHp;
    }

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        stats.OnHpChanged += HpChange;
    }
}
