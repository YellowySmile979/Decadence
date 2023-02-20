using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelExit : MonoBehaviour
{
    [HideInInspector] public bool hasKey = false;
    public string scene;

    //if player has picked up key load the scene we tell it to
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() && hasKey)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
