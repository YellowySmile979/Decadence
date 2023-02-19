using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerBeerShards : MonoBehaviour
{
    LevelManager levelmanager;
    public int damageToGive = 1;
    private bool damageFromSpike;
    public float timeBetweenEachDamage = 2f;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        levelmanager = FindObjectOfType<LevelManager>();
        damageFromSpike = false;
        //allows player to take damage on 1st collision
        timer = timeBetweenEachDamage;
    }
    private void Update()
    {
        //if player is in spikes, start the timer
        if (damageFromSpike)
        {
            timer += Time.deltaTime; //times when the player can start to take damage
            //when timer reaches max, player takes damage and timer is reset
            if (timer > timeBetweenEachDamage)
            {
                levelmanager.HurtPlayer(damageToGive);
                timer = 0;
            }
        }
    }
    //essentially says that the player can be damaged by the spikes as player is in it
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            damageFromSpike = true;
        }
    }
    //says that the player can no longer be damaged by the spike cause player aint in it
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            damageFromSpike = false;
        }
    }
}
