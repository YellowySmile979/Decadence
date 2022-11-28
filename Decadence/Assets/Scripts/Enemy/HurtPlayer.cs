using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    LevelManager theLevelManager; //makes a reference to the level manager
    public int damageToGive = 1; //says how much damage to deal to the player


    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();

    }

    //checks if player has walked into the spike
    void OnTriggerEnter2D(Collider2D other) //tells us what we r colliding with the words in the()
    {
        if (other.GetComponent<PlayerController>())
        {
            //theLevelManager.Respawn(); //call the respawn() function in the level manager script

            //says how much damage to deal based on the variable damageToGive
            theLevelManager.HurtPlayer(damageToGive);

        }
    }
}
