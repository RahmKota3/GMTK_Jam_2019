using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    EntityStats stats;

    bool takeDmg = false;
    bool respawn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hole")
        {
            // TODO: Falling in hole animation.
            takeDmg = true;
            respawn = true;
        }
        else if(collision.gameObject.tag == "Projectile")
        {
            takeDmg = true;
        }

        if (takeDmg)
        {
            stats.ChangeHpBy();

            if (respawn)
            {
                // TODO: Respawn.
            }

            takeDmg = false;
            respawn = false;
        }
    }

    private void Awake()
    {
        stats = GetComponent<EntityStats>();
    }
}
