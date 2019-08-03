using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance;

    [HideInInspector]
    public float HorizontalAxis;
    [HideInInspector]
    public float VerticalAxis;
    
    public Action OnShootPressed;
    public Action OnDashPressed;

    public bool WantsToMove = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        HorizontalAxis = Input.GetAxis("Horizontal");
        VerticalAxis = Input.GetAxis("Vertical");

        if (HorizontalAxis == 0 && VerticalAxis == 0)
            WantsToMove = false;
        else
            WantsToMove = true;
    }
}