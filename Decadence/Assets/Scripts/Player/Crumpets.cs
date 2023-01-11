using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumpets : MonoBehaviour
{
    public int maxDamageBoost = 1;
    int damageBoost;
    public int initialDamage = 1;
    int crumpetValue = 1;

    PlayerController pc;
    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        damageBoost = maxDamageBoost; //sets damage to the damage we deal
        pc = FindObjectOfType<PlayerController>();
        lm = FindObjectOfType<LevelManager>();
    }
    //when player touches the crumpet, disable the sprite renderer so that crumpets disappear
    //and then we set the damage to the damage boost
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            lm.AddCrumpets(crumpetValue);
            pc.SetDamage(damageBoost);
            Destroy(gameObject);
        }       
    }
}
