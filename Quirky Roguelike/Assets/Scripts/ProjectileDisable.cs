using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDisable : MonoBehaviour
{
    [SerializeField]
    float maxLifeTime = 3;

    float lifeTimer = 0;

    private void OnDestroy()
    {
        Debug.Log("KURWA WTF");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        //SimplePool.Despawn(gameObject);
    }

    private void OnEnable()
    {
        lifeTimer = 0;
    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer >= maxLifeTime)
        {
            gameObject.SetActive(false);
            //SimplePool.Despawn(gameObject);
        }
    }
}
