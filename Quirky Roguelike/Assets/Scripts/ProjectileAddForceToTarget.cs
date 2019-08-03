using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddForceToTarget : MonoBehaviour
{
    [SerializeField]
    float forceMagnitude = 30;

    Vector3 dir;

    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            Rigidbody2D collisionRb = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.GetComponent<EntityStats>().IsStunned = true;
            collisionRb.AddForce(dir * forceMagnitude * collisionRb.mass);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = rb.velocity.normalized;
    }
}
