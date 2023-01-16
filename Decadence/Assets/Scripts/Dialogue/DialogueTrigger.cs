using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public string diacontent;
    bool diatrigger = false;
    public TMP_Text dialogueLines;
    public GameObject theTextbox;

    PlayerController thePlayer;



    private void Start()
    {
        thePlayer = GetComponent<PlayerController>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            diatrigger = true;
            collision.attachedRigidbody.velocity = Vector2.zero;
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
        if(diatrigger == false)
        {
            theTextbox.SetActive(false);
        }

        if (diatrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            theTextbox.SetActive(true);
            dialogueLines.gameObject.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && dialogueLines == false)
        {
            theTextbox.SetActive(false);
        }
    }
}
