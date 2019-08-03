using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum Quirks { None, TileMovement, OneHp, MoveByShooting, OnlyBombs, OneBullet }

public class QuirkManager : MonoBehaviour
{
    public static QuirkManager Instance;
    
    public Quirks ActiveQuirk = Quirks.None;

    int playerHP;
    PlayerStats stats;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void QuirkSetup()
    {
        switch (ActiveQuirk)
        {
            case Quirks.OneHp:
                stats = FindObjectOfType<PlayerStats>();
                Debug.Log(stats.CurrentHp);
                playerHP = stats.CurrentHp;
                stats.ChangeHpBy(-stats.CurrentHp + 1);
                break;
        }
    }
    public void QuirkCleanup()
    {
        switch (ActiveQuirk)
        {
            case Quirks.OneHp:
                stats.ChangeHpBy(playerHP - 1);
                break;
        }
    }

}
