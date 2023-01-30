using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueBoxExit : MonoBehaviour
{
    [Header("Text To Display")]
    public string textToDisplay = "Element 1";
    public Text cutsceneText;
    public GameObject backgroundOfText;
    bool hasTyped = false;

    [Header("Text Scroll")]
    bool isTyping = false;
    public float delay = 0.01f;
    public float waitToDisableText;
    public bool ifIWantPlayerToStopAndRead;

    [Header("Scene")]
    public string Scene;
    public int requiredNumberOfKills = 1;
    public int numberOfEnemies;

    PlayerController player;

    //sets the required amount of enemies to kill before the player can progress
    public void EnemyKillCounter(int number)
    {
        numberOfEnemies += number;
    }
    void Reset()
    {
        requiredNumberOfKills = FindObjectsOfType<EnemyController>().Length;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        //basically if the text is done then turn the obhect off
        //so that the object doesnt play itself again
        if (hasTyped) SceneManager.LoadScene(Scene);
    }
    //when player triggers this, dialogue activates
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (numberOfEnemies >= requiredNumberOfKills && collision.GetComponent<PlayerController>())
        {
            SceneManager.LoadScene(Scene);
        }
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
        if (collision.GetComponent<PlayerController>())
        {
            StopAllCoroutines();
            cutsceneText.text = textToDisplay;
            isTyping = false;
        }
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
