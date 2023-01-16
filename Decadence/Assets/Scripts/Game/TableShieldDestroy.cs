using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableShieldDestroy : MonoBehaviour
{
    public float tableHP = 3;
    public GameObject enabledTable;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Projectile>())
        {
            tableHP--;
        }
        if(collision.collider.GetComponent<EnemyProjectile>())
        {
            tableHP--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(tableHP <= 0)
        {
            Destroy(enabledTable);
            Destroy(gameObject);
        }
    }
}
