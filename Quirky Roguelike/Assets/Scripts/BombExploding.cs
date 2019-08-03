using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExploding : MonoBehaviour
{
    float timeBeforeExplosion = 1.5f;

    float timer = 0;

    bool exploded = false;

    [SerializeField]
    Collider2D explosionRadius;
    [SerializeField]
    GameObject explosionSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<EntityStats>().ChangeHpBy();
    }

    void Explode()
    {
        explosionRadius.enabled = true;
        explosionSprite.SetActive(true);

        exploded = true;
    }

    private void OnEnable()
    {
        timer = 0;
        exploded = false;
    }

    private void OnDisable()
    {
        explosionSprite.SetActive(false);
        explosionRadius.enabled = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBeforeExplosion && exploded == false)
            Explode();
        else if (exploded && timer >= timeBeforeExplosion + 0.15f)
            SimplePool.Despawn(gameObject);
    }
}
