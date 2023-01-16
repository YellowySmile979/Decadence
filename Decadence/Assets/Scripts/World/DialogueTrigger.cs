using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    bool diatrigger = false;
    public TMP_Text dialoguelines;
    public GameObject theTextbox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            diatrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            diatrigger = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(diatrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            theTextbox.SetActive(true);
            dialoguelines.gameObject.SetActive(true);
        }
        else
        {
            theTextbox.SetActive(false);
        }
    }
}
