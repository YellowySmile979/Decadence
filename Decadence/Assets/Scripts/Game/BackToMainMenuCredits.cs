using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuCredits : MonoBehaviour
{
    //loads scene based on the string's name
    public void LoadScene(string name)
    {
        //loads scene with a name
        SceneManager.LoadScene(name);
    }
} 

