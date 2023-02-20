using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float bulletspeed = 5f;
    float direction;
    public float lifespan = 3f;
    public int damage = 1;

    Rigidbody2D rb;
    LevelManager lm;

    private void Start()
    {
        direction = Mathf.Sign(transform.localScale.x); //changes direction based on which direction player is facing
        Destroy(gameObject, lifespan);
        rb = GetComponent<Rigidbody2D>();
        lm = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //constantly set the bullet's speed
        rb.velocity = new Vector2(bulletspeed * direction, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.collider.GetComponent<PlayerController>();
        //prevents the bullet from destroying itself on colliders that aren't enemies
        if (other.collider.tag != "NO")
        {
            if (player != null)
            {
                lm.HurtPlayer(damage);
                Destroy(gameObject);
            }
            else Destroy(gameObject);
        }
    }
}
