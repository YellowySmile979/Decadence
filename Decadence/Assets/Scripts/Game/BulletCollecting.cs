using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollecting : MonoBehaviour
{
    //sets the value the bullet adds as ammo
    public int bulletAmmoValue = 1;
    public AudioClip bulletPickUpSound;

    Weapon weapon;
    AudioSource audioSource;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        weapon = FindObjectOfType<Weapon>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }
    //when player collides with bullet, ammo is added and is destroyed
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            if (sr.enabled == true)
            {
                weapon.AddAmmo(bulletAmmoValue); //adds ammo
                audioSource.PlayOneShot(bulletPickUpSound); //plays the bullet pickup noise
            }
            sr.enabled = false;            
            Destroy(gameObject,1f); //part that destroys the object

        }
    }   
}
