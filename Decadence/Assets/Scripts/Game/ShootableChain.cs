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
        fc = FindObjectOfType<FallingCrate>();
        lm = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            lm.DropBoxOrChain();
            Destroy(gameObject, 0.5f);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<ShootableChain>())
        {
            lm.DropBoxOrChain();
        }
    }
    
}
