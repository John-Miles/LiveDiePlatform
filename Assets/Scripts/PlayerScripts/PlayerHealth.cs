using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    
    public int health = 100;
    public GameObject playerDeathEffect;
    
    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        //creates an effect whenever an enemy dies
        //Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SoundManager.PlaySound("dead");
        GameManager.instance.platformSpawnPos = gameObject.transform.position;
        GameManager.instance.RespawnPlayer();
        GameManager.instance.SpawnPlatform();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.platformSpawnPos = gameObject.transform.position;
            Destroy(gameObject);
            SoundManager.PlaySound("dead");
            GameManager.instance.RespawnPlayer();
            GameManager.instance.SpawnPlatform();

        }

        if (other.gameObject.CompareTag("Finish"))
        {
            StartCoroutine("NextLevel");
        }
        
        if (other.gameObject.CompareTag("DeathBarrier"))
        {
            Destroy(gameObject);
            SoundManager.PlaySound("dead");
            GameManager.instance.RespawnPlayer();
            
        }
    }

    IEnumerator NextLevel()
    {
        SoundManager.PlaySound("finish");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
