using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumpets : MonoBehaviour
{
    public float maxdamageBoostDuration = 5f;
    float damageBoostDuration;
    public int maxDamageBoost = 2;
    int damageBoost;
    public int initialDamage = 1;

    Projectile projectile;

    // Start is called before the first frame update
    void Start()
    {
        damageBoostDuration = maxdamageBoostDuration;
        damageBoost = maxDamageBoost;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            Destroy(gameObject);

        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (damageBoostDuration<=0)
        {
            projectile.SetDamage(initialDamage);

        }
    }
}
