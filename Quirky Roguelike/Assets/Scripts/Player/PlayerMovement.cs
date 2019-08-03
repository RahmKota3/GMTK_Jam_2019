using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    void Move()
    {
        rb.velocity = SpeedCalculator.CalculateSpeed();
    }

    void ResetVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (InputManager.Instance.WantsToMove)
            Move();
        else
            ResetVelocity();
    }
}
