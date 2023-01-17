using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 2;
    int checkForHalfHealth;
    int enemyIncreaseNumber = 1;
    public Sprite bloodied;


    PopUpExit puExit;
    SpriteRenderer sr;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        puExit = FindObjectOfType<PopUpExit>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        checkForHalfHealth = health / 2; //sets this variable to be half health
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("HalfHealth", checkForHalfHealth);
        //when half health switch the sprite
        if(health == checkForHalfHealth)
        {
            sr.sprite = bloodied;
        }
    }
    //when bullet collides with collider, enemy's health is reduced. if enemies health is equal to or less than 0,
    //increase number of enemies still needed to be killed and perform Die() 
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            puExit.EnemyKillCounter(enemyIncreaseNumber);
            Die();
             
        }
    }
    //deletes the enemy
    public void Die()
    {        
        Destroy(gameObject);
    }
}
