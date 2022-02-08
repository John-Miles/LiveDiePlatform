using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform shootingPoint;
    public Transform player;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public GameObject enemybulletPrefab;
    public float shotDelay;
    public float startShotDelay;


    private void Start()
    {
        //get the position of the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shotDelay = startShotDelay;
    }

    

    void Update()
    {
       if (shotDelay <= 0)
        {
            SoundManager.PlaySound("enemyShot");
            Instantiate(enemybulletPrefab, shootingPoint.position, Quaternion.identity);
            
            Debug.Log("Shooting at Player!");
            shotDelay = startShotDelay;
        }
        else
        {
            shotDelay -= Time.deltaTime; 
        }
    }
}
