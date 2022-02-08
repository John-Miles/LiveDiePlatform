using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip deathSFX, enemyShot, playerShot, playerJump, levelFinish, hitSound, buttonClick;
    private static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        playerShot = Resources.Load<AudioClip>("player_shoot");
        deathSFX = Resources.Load<AudioClip>("dead_sound");
        enemyShot = Resources.Load<AudioClip>("enemy_shoot");
        playerJump = Resources.Load<AudioClip>("player_jump");
        levelFinish = Resources.Load<AudioClip>("level_finish");
        hitSound = Resources.Load<AudioClip>("hit_sound");
        buttonClick = Resources.Load<AudioClip>("button_click");

        audioSrc = GetComponent<AudioSource>();
    }

  
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSrc.PlayOneShot(playerShot);
                break;
            case "dead":
                audioSrc.PlayOneShot(deathSFX);
                break;
            case "enemyShot":
                audioSrc.PlayOneShot(enemyShot);
                break;
            case "jump":
                audioSrc.PlayOneShot(playerJump);
                break;
            case "finish":
                audioSrc.PlayOneShot(levelFinish);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "click":
                audioSrc.PlayOneShot(buttonClick);
                break;
        }
    }
}
