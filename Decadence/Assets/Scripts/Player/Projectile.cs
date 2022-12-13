using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletspeed = 5f;
    float direction = 1;
    public float lifespan = 3f;
    public int maxdamage = 1;
    int damage;

    //to change the direction the sprite is facing in relation to the player
    private void Start()
    {
        damage = maxdamage;
        direction = Mathf.Sign(transform.localScale.x);
        Destroy(gameObject, lifespan); //destroys bullet based on it's lifespan
    }
    public void SetDamage(int dmg)
    {
        damage += dmg;
    }
    // Update is called once per frame
    void Update()
    {
        //sets bullet speed and direction of movement
        transform.position += transform.right * direction * Time.deltaTime * bulletspeed;
    }
    //when bullet collides with enemy's collider, enemy takes damage based on TakeDamage function
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (other.tag != "NO") //allows us to prevent ALL colliders from destroying the bullet
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        //this is so that the PopUpExit script does not interfere with Act 1
        Act1EnemyController enemy1 = other.GetComponent<Act1EnemyController>();
        if (other.tag != "NO") //allows us to prevent ALL colliders from destroying the bullet
        {
            if (enemy1 != null)
            {
                enemy1.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }   
}
