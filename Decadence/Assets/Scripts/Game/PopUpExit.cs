using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopUpExit : MonoBehaviour
{
    public int numberOfEnemies;
    public int requiredNumberOfKills = 1;

    MeshRenderer mr;
    
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        
    }
    //when player collides with collider, enable the mesh renderer
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            mr.enabled = true;

        }
        if (numberOfEnemies >= requiredNumberOfKills)
        {
            SceneManager.LoadScene("Act 2 Level 2");
            
        }
    }
    //when player interacts with collider, msg will appear
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            mr.enabled = false;

        }
    }
    //sets the required amount of enemies to kill before the player can progress
    public void EnemyKillCounter(int number)
    {
        numberOfEnemies += number;
        
    }
}
