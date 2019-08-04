using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Transform barrel;
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float shootingCooldown = 0.25f;

    Rigidbody2D rb;
    PlayerStats stats;

    float shotTimer = 1;

    void Shoot()
    {
        if (QuirkManager.Instance.ActiveQuirk == Quirks.OnlyBombs)
            return;

        if (shotTimer >= shootingCooldown)
        {
            GameObject p = SimplePool.Spawn(projectile, barrel.position, barrel.rotation);

            shotTimer = 0;

            if(QuirkManager.Instance.ActiveQuirk == Quirks.MoveByShooting)
            {
                rb.AddForce(-barrel.transform.right * stats.ShootingQuirkKnockback);
            }
        }
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
        InputManager.Instance.OnShootPressed += Shoot;
    }

    private void Update()
    {
        shotTimer += Time.deltaTime;

        if (QuirkManager.Instance.ActiveQuirk == Quirks.HalfScreenVisible && shotTimer >= shootingCooldown)
            Shoot();
    }
}
