using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumpets : MonoBehaviour
{
    public int initialDamage = 1;
    int crumpetValue = 1;
    public AudioClip CrumpetPickUpSound;

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
    //when player touches the crumpet, disable the sprite renderer so that crumpets disappear
    //and then we set the damage to the damage boost
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            if(sr.enabled == true)
            {
                audioSource.PlayOneShot(CrumpetPickUpSound); //plays audio for picking it up
                lm.AddCrumpets(crumpetValue);
            }
            sr.enabled = false;
            Destroy(gameObject, 1f);
        }       
    }
}
