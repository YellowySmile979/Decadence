using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1BulletCollecting : MonoBehaviour
{
    //sets the value the bullet adds as ammo
    public int bulletAmmoValue = 1;

    Weapon weapon;
    Level2Transition lt;

    //when player collides with bullet, ammo is added and is destroyed
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            weapon.AddAmmo(bulletAmmoValue); //adds ammo

            lt.BulletPickupCounter(bulletAmmoValue); //counts towards the final bullet counter so that nothing goes wrong

            Destroy(gameObject); //part that destroys the object

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        weapon = FindObjectOfType<Weapon>();
        lt = FindObjectOfType<Level2Transition>();

    }
}
