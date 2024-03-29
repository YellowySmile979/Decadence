using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 2;
    float checkForHalfHealth;
    int enemyIncreaseNumber = 1;
    bool isHalfHealth = false;
    public Sprite bloodied;


    DialogueBoxExit dialogueBoxExit;
    SpriteRenderer sr;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBoxExit = FindObjectOfType<DialogueBoxExit>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        checkForHalfHealth = Mathf.Floor(enemyHealth / 2); //sets this variable to be half health
    }
    // Update is called once per frame
    void Update()
    {   
        //when half health switch the sprite
        if(enemyHealth <= checkForHalfHealth)
        {
            sr.sprite = bloodied;
            isHalfHealth = true;
        }
        if(isHalfHealth == true)
        {
            anim.SetBool("HalfHealth", true);
        }
        anim.SetBool("HalfHealth", isHalfHealth);
    }
    //when bullet collides with collider, enemy's health is reduced. if enemies health is equal to or less than 0,
    //increase number of enemies still needed to be killed and perform Die() 
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            dialogueBoxExit.EnemyKillCounter(enemyIncreaseNumber);
            Die();
             
        }
    }
    //deletes the enemy
    public void Die()
    {        
        Destroy(gameObject);
    }
}
