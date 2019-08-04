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

    bool hasABullet = true;

    void Shoot()
    {
        if (QuirkManager.Instance.ActiveQuirk == Quirks.OnlyBombs)
            return;

        if (shotTimer >= shootingCooldown && (QuirkManager.Instance.ActiveQuirk != Quirks.OneBullet || 
            (QuirkManager.Instance.ActiveQuirk == Quirks.OneBullet && hasABullet)))
        {
            //GameObject p = SimplePool.Spawn(projectile, barrel.position, barrel.rotation);
            GameObject p = Instantiate(projectile, barrel.position, barrel.rotation);

            shotTimer = 0;

            if(QuirkManager.Instance.ActiveQuirk == Quirks.MoveByShooting)
            {
                rb.AddForce(-barrel.transform.right * stats.ShootingQuirkKnockback);
            }

            hasABullet = false;
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
