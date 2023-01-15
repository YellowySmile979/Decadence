using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tea : MonoBehaviour
{
    //sets how much health to give player
    public int maxHealthToGive = 5;
    int healthToGive;
    public AudioClip drinkingSound;

    LevelManager lm;
    AudioSource audioSource;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }
    //when player collides with tea collider, heal player by health to give and then destroy the object
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            if(sr.enabled == true)
            {
                audioSource.PlayOneShot(drinkingSound);
                healthToGive = maxHealthToGive;
                lm.HealPlayer(healthToGive);
            }
            sr.enabled = false;
            Destroy(gameObject, 2f);

        }
    }
}
