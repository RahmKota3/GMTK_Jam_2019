using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    [SerializeField]
    GameObject bombPrefab;

    float bombCooldown = 3f;
    float bombTimer;

    void ThrowABomb()
    {
        if (QuirkManager.Instance.ActiveQuirk != Quirks.OnlyBombs)
            return;

        if (bombTimer >= bombCooldown)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            //SimplePool.Spawn(bombPrefab, transform.position, Quaternion.identity);
            bombTimer = 0;
        }
    }

    private void Start()
    {
        InputManager.Instance.OnShootPressed += ThrowABomb;
        bombTimer = bombCooldown;
    }

    private void Update()
    {
        bombTimer += Time.deltaTime;
    }
}
