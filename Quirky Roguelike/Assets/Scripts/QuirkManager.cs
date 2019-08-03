using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum Quirks { None, TileMovement }

public class QuirkManager : MonoBehaviour
{

    public static QuirkManager Instance;

    public Quirks ActiveQuirk = Quirks.None;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

}
