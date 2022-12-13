using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 2;
    int enemyIncreaseNumber = 1;


    PopUpExit puExit;

    // Start is called before the first frame update
    void Start()
    {
        puExit = FindObjectOfType<PopUpExit>();
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {            
            Die();
             
        }
    }

    public void Die()
    {
        puExit.EnemyKillCounter(enemyIncreaseNumber);
        Destroy(gameObject);
    }
}
