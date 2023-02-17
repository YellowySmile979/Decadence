using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float bulletspeed = 5f;//how fast is the bullet
    float direction;//what direction is the bullet
    public float lifespan = 3f;//how long the bullet last without colliding with a collider
    public int damage = 1;//how much damage it does

    Rigidbody2D rb;//calling component
    LevelManager lm;//calling levelmanager

    private void Start()
    {
        direction = Mathf.Sign(transform.localScale.x);//direction of bullet
        Destroy(gameObject, lifespan);//destroy itself after a certain ammount of time
        rb = GetComponent<Rigidbody2D>();//calling rigidbody2d
        lm = FindObjectOfType<LevelManager>();//calling levelmanager
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(bulletspeed * direction, 0);//how the bullet moves
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        PlayerController player = other.collider.GetComponent<PlayerController>();

        if (other.collider.tag != "NO")
        {
            if (player != null)
            {
                lm.HurtPlayer(damage);
                Destroy(gameObject);
            }
            else Destroy(gameObject);            
        }
    }//hurting the player or destroy itself when collidng with a collider
}
