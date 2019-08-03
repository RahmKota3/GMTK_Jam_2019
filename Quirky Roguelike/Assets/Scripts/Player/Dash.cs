using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float dashCooldown = 1;
    [SerializeField]
    float dashForce = 5000;

    float dashTimer = 1;
    
    PlayerMovement movement;

    void PerformDash()
    {
        if (QuirkManager.Instance.ActiveQuirk == Quirks.MoveByShooting)
            return;

        if (dashTimer >= dashCooldown)
        {
            Vector2 forceDir = transform.right * InputManager.Instance.HorizontalAxis + transform.up * InputManager.Instance.VerticalAxis;
            rb.AddForce(forceDir.normalized * dashForce);

            dashTimer = 0;
            movement.CanMove = false;
        }
    }

    private void Start()
    {
        InputManager.Instance.OnDashPressed += PerformDash;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        dashTimer += Time.deltaTime;

        if (dashTimer >= 0.25f)
            movement.CanMove = true;
    }
}
