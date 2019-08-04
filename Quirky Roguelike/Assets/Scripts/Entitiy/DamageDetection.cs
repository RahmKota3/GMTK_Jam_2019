using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    EntityStats stats;

    public float RespawnSafeDistance;

    bool takeDmg = false;
    bool respawn = false;

    public List<GameObject> respawns = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hole")
        {
            // TODO: Falling in hole animation.
            takeDmg = true;
            respawn = true;
        }
        else if(collision.gameObject.tag == "Projectile" && gameObject.tag == "Player")
        {
            takeDmg = true;
        }
        else if(collision.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Enemy")
        {
            takeDmg = true;
        }

        if (takeDmg)
        {
            stats.ChangeHpBy();

            if (respawn)
            {
                Respawn();
                // TODO: Respawn.
            }

            takeDmg = false;
            respawn = false;
        }
    }

    void Respawn()
    {
        for(int i = 0; i < respawns.Count; i++)
        {
            if (CheckClosestEnemies(respawns[i].transform.position))
            {
                transform.position = respawns[i].transform.position;
            }
        }
    }

    bool CheckClosestEnemies(Vector2 _position)
    {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector2 position = _position;
            float rememberedDistance = 10000;
        for (int i = 0; i < gos.Length; i++)
        {
            Vector2 diff = new Vector2(gos[i].transform.position.x - _position.x, gos[i].transform.position.y - _position.y);
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = gos[i];
                distance = curDistance;
                rememberedDistance = distance;
            }
        }
        if (rememberedDistance > RespawnSafeDistance)
        {
            return true;
        }
        else {
            return false;
        }
    }

    private void Awake()
    {
        stats = GetComponent<EntityStats>();
    }
}
