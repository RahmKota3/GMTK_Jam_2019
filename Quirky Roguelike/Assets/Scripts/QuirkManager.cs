using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum Quirks { None, TileMovement, OneHp, MoveByShooting, OnlyBombs, OneCrazyBullet, HalfScreenVisible, OneBullet }

public class QuirkManager : MonoBehaviour
{
    public static QuirkManager Instance;
    
    public Quirks ActiveQuirk = Quirks.None;

    public Action OnQuirkChange;

    [SerializeField]
    GameObject screenHiderPrefab;

    GameObject screenHiderInstance;

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
            case Quirks.HalfScreenVisible:
                screenHiderInstance = Instantiate(screenHiderPrefab, Vector3.zero, Quaternion.identity);
                break;
        }
    }
    public void QuirkCleanup()
    {
        if (OnQuirkChange != null)
            OnQuirkChange.Invoke();

        switch (ActiveQuirk)
        {
            case Quirks.OneHp:
                stats.ChangeHpBy(playerHP - 1);
                break;
        }
    }

}
