using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletspeed = 5f;
    float direction = 1;
    public float lifespan = 3f;
    public int damage = 1;

    //to change the direction the sprite is facing in relation to the player
    private void Start()
    {
        direction = Mathf.Sign(transform.localScale.x);
        Destroy(gameObject, lifespan); //destroys bullet based on it's lifespan
    }

    // Update is called once per frame
    void Update()
    {
        //sets bullet speed and direction of movement
        transform.position += transform.right * direction * Time.deltaTime * bulletspeed;
    }
    //when bullet collides with enemy's collider, enemy takes damage based on TakeDamage function
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
