using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlip : MonoBehaviour
{
    public GameObject enabledTable;
    public GameObject disabledTable;

    bool isPlayerOnIt = false;

    //when player is on the trigger, set the variable to true so to say that player is on it
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            isPlayerOnIt = true;
        }
    }
    //when player is not on the trigger, set the variable to false so to say that player is not on it
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            isPlayerOnIt = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if the player is on it and the player presses E, disable this table and enable the other table
        if(isPlayerOnIt == true && Input.GetKeyDown(KeyCode.E))
        {
            enabledTable.SetActive(false);
            disabledTable.SetActive(true);
        }
    }
}
