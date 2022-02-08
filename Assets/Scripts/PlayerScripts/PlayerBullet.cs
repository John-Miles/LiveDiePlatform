using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f;
    public float timeout;
    public int damageToEnemy;
    public GameObject bulletHitEffect;
    
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
        SoundManager.PlaySound("hit");
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.Damage(damageToEnemy);
        }
        //creates a bullet effect whenever something is hit
        //Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log(other.name);
    }
}
