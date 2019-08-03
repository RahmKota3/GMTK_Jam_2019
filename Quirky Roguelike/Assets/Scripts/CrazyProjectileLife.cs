using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyProjectileLife : MonoBehaviour
{
    [SerializeField]
    float speed = 15;
    [SerializeField]
    float maxSpeed = 30;

    [SerializeField]
    Rigidbody2D rb;

    // rb.velocity = transform.right * speed;
    private Vector2 kierunek;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MapBoundry1")
        {
            Debug.Log("Górna ściana");
            kierunek = new Vector2(Random.Range(-6.0f, 6.0f), Random.Range(3.0f, -6.0f)).normalized;
        }
        else if (collision.name == "MapBoundry2")
        {
            Debug.Log("Dolna ściana");
            kierunek = new Vector2(Random.Range(-6.0f, 6.0f), Random.Range(3.0f, 6.0f)).normalized;
        }
        else if (collision.name == "MapBoundry3")
        {
            Debug.Log("Lewa ściana");
            kierunek = new Vector2(Random.Range(3.0f, 6.0f), Random.Range(-6.0f, 6.0f)).normalized;
        }
        else if (collision.name == "MapBoundry4")
        {
            Debug.Log("prawa ściana");
            kierunek = new Vector2(Random.Range(3.0f, -6.0f), Random.Range(-6.0f, 6.0f)).normalized;
        }
        else
        {
            kierunek = new Vector2(Random.Range(-6.0f, 6.0f), Random.Range(-6.0f, 6.0f)).normalized;
        }
        if (speed < maxSpeed)
        {
            speed += 5;
        }
        
        rb.velocity = kierunek * speed;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > 40)
        {
            transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        }
    }
}
