using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 2;
    public int damageIncreaseNumber = 1;


    PopUpExit puExit;

    // Start is called before the first frame update
    void Start()
    {
        puExit = GetComponent<PopUpExit>();
        
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
        Destroy(gameObject);
    }
}
