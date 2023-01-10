using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumpets : MonoBehaviour
{
    public float maxDamageBoostDuration = 5f;
    float damageBoostDuration;
    public int maxDamageBoost = 1;
    int damageBoost;
    public int initialDamage = 1;
    int crumpetValue = 1;

    PlayerController pc;
    SpriteRenderer sr;
    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        damageBoostDuration = maxDamageBoostDuration; //sets the time that damage boost lasts for
        damageBoost = maxDamageBoost; //sets damage to the damage we deal
        pc = FindObjectOfType<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
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
