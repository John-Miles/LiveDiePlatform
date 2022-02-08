using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyLeftBullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject enemy;

    public float speed = 20f;
    public float timeout;
    public int damageToPlayer;
    public GameObject bulletHitEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    private void Awake()
    {
        timeout = 50;
    }

    private void FixedUpdate()
    {
        timeout--;
        if (timeout <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("I Hit a Bullet!");
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.Damage(damageToPlayer);
            }
            //creates a bullet effect whenever something is hit
            //Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log(other.name);
        }

        if (other.gameObject.CompareTag("Untagged"))
        {
            Destroy(gameObject);
            //Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
        }
        
        
    }
}