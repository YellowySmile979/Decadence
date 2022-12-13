using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2Transition : MonoBehaviour
{
    public int requiredNumberOfBullets = 1;
    public int numberOfBullets;

    MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();

    }

    //upon entering the trigger, the trigger activates
    void OnTriggerEnter2D(Collider2D other)
    //prevents other colliders from loading scenes like bullets
    {
        //only activates if both the player AND all the required bullets have been collected
        if (other.GetComponent<PlayerController>() && numberOfBullets >= requiredNumberOfBullets) 
        {
            //loads scene named level 2
            SceneManager.LoadScene("Act 2 Level 1");

        }
        //enables the MeshRenderer if player steps into the collider
        if(other.GetComponent<PlayerController>())
        {
            mr.enabled = true;

        }
    }
    //when player exits the collider, disable popup
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            mr.enabled = false;

        }
    }
    public void BulletPickupCounter(int number)
    {
        numberOfBullets += number;

    }
}
