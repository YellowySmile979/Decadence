using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1Transition : MonoBehaviour
{
    //upon entering the trigger, the trigger activates
    void OnTriggerEnter2D(Collider2D other) 
        //prevents other colliders from loading scenes like bullets
        {
            if (other.GetComponent<PlayerController>())
            {
                //loads scene named level 2
                SceneManager.LoadScene("Level 2");

            }
        }

    }


