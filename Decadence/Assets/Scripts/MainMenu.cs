using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //command for button named new game
    public void NewGame()
    {
        //loads scene named level 1 tutorial
        SceneManager.LoadScene("Level 1 (Tutorial)");
    }

    //allows for the game to be quit from
    public void QuitGame()
    {
        //quits the application aka game
        Application.Quit();
    }
    //loads scene based on the string's name
    public void LoadScene(string name)
    {
        //loads scene with a name
        SceneManager.LoadScene(name);
    }
}
