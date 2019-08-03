using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInitialForce : MonoBehaviour
{
    [SerializeField]
    float speed = 15;

    [SerializeField]
    Rigidbody2D rb;
    
    private void OnEnable()
    {
        rb.velocity = transform.right * speed;
    }
}
