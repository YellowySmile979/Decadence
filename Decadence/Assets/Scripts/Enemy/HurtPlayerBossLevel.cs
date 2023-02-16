using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerBossLevel : MonoBehaviour
{
    public int damageToDeal = 3;
    bool hasDealtDamage;

    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        hasDealtDamage = false;
    }
    //checks to see if player has
    //a. more than 3 hp
    //b. hasnt already dealt the dmg
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() && hasDealtDamage && lm.healthTracker > 3)
        {
            lm.HurtPlayer(damageToDeal);
            hasDealtDamage = true;
        }
    }
}
