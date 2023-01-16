using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletspeed = 15f;
    float direction = 1;
    public float lifespan = 3f;
    public int maxdamage = 1;
    int damage;
    Rigidbody2D rb;

    PlayerController pc;

    //to change the direction the sprite is facing in relation to the player
    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        damage = maxdamage;
        direction = Mathf.Sign(transform.localScale.x);
        Destroy(gameObject, lifespan); //destroys bullet based on it's lifespan
    }
    
    // Update is called once per frame
    void Update()
    {
        //sets bullet speed and direction of movement
        rb.velocity = new Vector2(bulletspeed * direction, 0);
        
        
        damage = pc.damg;
    }
    //when bullet collides with enemy's collider, enemy takes damage based on TakeDamage function
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController enemy = other.collider.GetComponent<EnemyController>();
        if (other.collider.tag != "NO") //allows us to prevent ALL colliders from destroying the bullet
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
            if (other.collider.GetComponent<Joint2D>())
            {
                Destroy(other.collider.GetComponent<Joint2D>());
                Destroy(this);
            }
        }
    }   
}
