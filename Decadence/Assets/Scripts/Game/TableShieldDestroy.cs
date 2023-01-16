using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableShieldDestroy : MonoBehaviour
{
    public float tableHP = 3;
    public GameObject enabledTable;
    
    //checks to see if specifically bullets from either the player or the enemy and then minus health
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Projectile>())
        {
            tableHP--; //miuses hp by 1
        }
        if(collision.collider.GetComponent<EnemyProjectile>())
        {
            tableHP--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if table hp reaches zero destroy the original table and this one
        if(tableHP <= 0)
        {
            Destroy(enabledTable);
            Destroy(gameObject);
        }
    }
}
