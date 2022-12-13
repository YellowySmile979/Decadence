using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1EnemyController : MonoBehaviour
{
    //THIS ENTIRE SCRIPT IS SO THAT THIS LINE:
    //puExit.EnemyKillCounter(enemyIncreaseNumber); DOES NOT AFFECT ACT 1

    public int health = 2;
    //when bullet collides with collider, enemy's health is reduced. if enemies health is equal to or less than 0,
    //increase number of enemies still needed to be killed and perform Die()
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();

        }
    }
    //deletes the enemy
    public void Die()
    {
        Destroy(gameObject);
    }
}
