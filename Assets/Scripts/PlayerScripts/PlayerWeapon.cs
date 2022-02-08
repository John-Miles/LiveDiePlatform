using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform shootingPoint;

    public GameObject playerBulletPrefab;
    
    // Update is called once per frame
    void Update()
    {
        //allow the enemy to shoot a projectile
        //enemy should be able to shoot 1 bullet every second
        if(Input.GetButtonDown("Fire1"))
            Instantiate(playerBulletPrefab, shootingPoint.position, shootingPoint.rotation);
        
    }
}
