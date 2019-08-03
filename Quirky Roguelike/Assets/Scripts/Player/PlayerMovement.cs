using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public bool CanMove = true;
    
    void Move()
    {
        rb.velocity = SpeedCalculator.CalculateSpeed();
    }

    void ResetVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    private void Start()
    {
        InputManager.Instance.OnDashPressed += ResetVelocity;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (InputManager.Instance.WantsToMove && CanMove)
            Move();
        else if(CanMove != false)
            ResetVelocity();
    }
}
