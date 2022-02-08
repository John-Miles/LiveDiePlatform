
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    //public GameObject enemyDeathEffect;

    public void Damage(int damage)
    {
        health -= damage;
        //Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //creates ann effect whenever an enemy dies
        Destroy(gameObject);
        SoundManager.PlaySound("dead");
        //Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        

    }
}
