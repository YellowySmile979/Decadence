using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject areYouSure;
    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //when i press the binded cancel key AKA "esc", then check if time is paused or not and do the corresponding funcs
        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 0) ResumeGame();
            else PauseGame();
        }
    }
    //pauses time and hence the game
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        pc.canMove = false; //prevents player from moving while the game is paused
        pc.GetComponent<AudioSource>().Stop(); //turns off the bgm
    }
    //resumes time and hence the game
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        pc.canMove = true; //allows player to move again once game is resumed
        pc.GetComponent<AudioSource>().Play(); //resumes the bgm
    }
    public void TurnOnAreYouSure()
    {
        areYouSure.SetActive(true);
    }
    public void TurnOffAreYouSure()
    {
        areYouSure.SetActive(false);
    }
}
