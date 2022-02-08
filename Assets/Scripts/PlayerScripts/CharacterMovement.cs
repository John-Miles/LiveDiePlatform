using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private float horizontalMove = 0;
    public bool jump = false;
    public bool crouch = false;
    public float runSpeed = 40f;

    public Animator animator;
    
    public Transform shootingPoint;
    public GameObject playerBulletPrefab;

    private void Update()
    {
        
        //movement controls
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        
        

        if (Input.GetButtonDown("Jump"))
        {
            
           animator.SetBool("IsJumping",true);
           SoundManager.PlaySound("jump");
           jump = true;
            
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
        //shooting controls
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(playerBulletPrefab, shootingPoint.position, shootingPoint.rotation);
            SoundManager.PlaySound("fire");
        }
            
    }
    
    public void OnLanding()
    {
        animator.SetBool("IsJumping",false);
    }

    private void FixedUpdate()
    {
        //move the player
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
        



    }
}