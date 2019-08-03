using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerStats stats;

    public bool CanMove = true;

    float movementCooldown = 0.5f;
    float movementTimer = 0;

    float tileMovementDistance = 1.5f;

    [SerializeField]
    LayerMask unwalkableForPlayer;
    
    void Move()
    {
        if (QuirkManager.Instance.ActiveQuirk != Quirks.TileMovement)
        {
            if (rb.velocity.magnitude < stats.MaxSpeed)
                rb.velocity += SpeedCalculator.CalculateSpeed();
        }
        else if (movementTimer <= 0)
        {
            movementTimer = movementCooldown;
            Vector3 tileMovementVector = new Vector3(InputManager.Instance.HorizontalAxis,
                InputManager.Instance.VerticalAxis) * tileMovementDistance;

            RaycastHit2D hit = Physics2D.CircleCast(transform.position + tileMovementVector, 0.5f, Vector3.forward, 1, unwalkableForPlayer);
            if (hit == false)
                transform.position += tileMovementVector;
        }
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
        stats = GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        if (InputManager.Instance.WantsToMove && CanMove)
            Move();
        else if(CanMove != false)
            ResetVelocity();
    }

    private void Update()
    {
        movementTimer = Mathf.Clamp(movementTimer - Time.deltaTime, 0, 10);
    }
}
