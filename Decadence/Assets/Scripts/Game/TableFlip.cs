using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlip : MonoBehaviour
{
    public GameObject enabledTable;
    public GameObject disabledTable;

    bool isPlayerOnIt = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            isPlayerOnIt = true;
        }
    }
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
        if(isPlayerOnIt == true && Input.GetKeyDown(KeyCode.E))
        {
            enabledTable.SetActive(false);
            disabledTable.SetActive(true);
        }
    }
}
