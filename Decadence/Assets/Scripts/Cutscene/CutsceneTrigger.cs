using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTrigger : MonoBehaviour
{
    public string nextScene; 
    CutsceneManager CSManager;

    bool trigger = false;
    //to detect trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() )
                //if collided is a player
        {
            trigger = true;
                //trigger is present
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            trigger = false;
        }
    }
    
    private void Update()
    {
        if(trigger == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadSceneAsync(nextScene);
        }
    }
    
    

    //the reason why it doesnt work if its just trigger enter is because of timing :)
}
