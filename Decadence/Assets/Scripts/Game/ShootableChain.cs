using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableChain : MonoBehaviour
{
    Rigidbody2D rb;
    FallingCrate fc;
    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fc = GetComponentInParent<FallingCrate>();
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            fc.DropBoxOrChain();
        }
    }
    
   

}
