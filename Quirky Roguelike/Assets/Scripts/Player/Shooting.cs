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

    float shotTimer = 1;

    void Shoot()
    {
        if (shotTimer >= shootingCooldown)
        {
            GameObject p = SimplePool.Spawn(projectile, barrel.position, barrel.rotation);

            shotTimer = 0;
        }
    }

    private void Awake()
    {
        //SimplePool.Preload(projectile, 30);
    }

    private void Start()
    {
        InputManager.Instance.OnShootPressed += Shoot;
    }

    private void Update()
    {
        shotTimer += Time.deltaTime;
    }
}
