using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxEnemy : MonoBehaviour
{
    [Header("Text To Display")]
    [TextArea] public string textToDisplay = "Element 1";
    public Text cutsceneText;
    public GameObject backgroundOfText;
    bool thugHasDied = false;

    [Header("Text Scroll")]
    bool isTyping = false;
    public float delay = 0.01f;
    public float waitToDisableText = 1f;
    public bool ifIWantPlayerToStopAndRead;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        //deactivates the gameobject if the thug has died
        if (thugHasDied)
        {
            cutsceneText.text = "";
            backgroundOfText.SetActive(false);
            player.canMove = true;
            gameObject.SetActive(false);
        }
    }
    //when player triggers this, dialogue activates
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            //specifically if i want the player to stop and read
            if (ifIWantPlayerToStopAndRead)
            {
                player.canMove = false;
                player.rb.velocity = new Vector2(0, 0);
            }
            backgroundOfText.SetActive(true);
            if (!isTyping)
            {
                StartCoroutine(TypeOutText(textToDisplay));
            }
        }
    }
    //when player exits collider, immediately deactivates everything, displays the text fully
    //and turns the dialogue box off
    void OnTriggerExit2D(Collider2D collision)
    {
        //when thug is killed, set the bool thugHasDied to true
        if (collision.GetComponent<EnemyController>()) thugHasDied = true;

        if (collision.GetComponent<PlayerController>())
        {
            StopAllCoroutines();
            cutsceneText.text = textToDisplay;
            isTyping = false;
            StartCoroutine(DeactivateAll());
        }
    }
    //deactivates everything after waiting awhile
    //also allows player to continue moving since there was a bug
    IEnumerator DeactivateAll()
    {
        yield return new WaitForSeconds(1);
        cutsceneText.text = "";
        backgroundOfText.SetActive(false);
        player.canMove = true;
    }
    //types out each letter of the text for that dialogue effect
    IEnumerator TypeOutText(string message)
    {
        isTyping = true;
        //empties the text and this string will be filled
        cutsceneText.text = "";
        //is how the text is loaded
        for (int i = 0; i < message.Length; i++)
        {
            cutsceneText.text += message[i];
            yield return new WaitForSeconds(delay);
        }
        isTyping = false;
        player.canMove = true;
        yield return new WaitForSeconds(waitToDisableText);
        cutsceneText.text = "";
        backgroundOfText.SetActive(false);
    }
}
