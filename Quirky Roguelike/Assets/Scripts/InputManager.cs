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

    void CheckInput()
    {
        // Check axis
        HorizontalAxis = Input.GetAxis("Horizontal");
        VerticalAxis = Input.GetAxis("Vertical");

        if (HorizontalAxis == 0 && VerticalAxis == 0)
            WantsToMove = false;
        else
            WantsToMove = true;

        // Check fire button
        if (Input.GetButton("Fire1") && OnShootPressed != null)
            OnShootPressed.Invoke();

        // Check dash button
        if (Input.GetButtonDown("Dash") && OnDashPressed != null)
            OnDashPressed.Invoke();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        CheckInput();
    }
}