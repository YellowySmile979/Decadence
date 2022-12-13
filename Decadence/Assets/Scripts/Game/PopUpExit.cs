using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopUpExit : MonoBehaviour
{
    public int numberOfEnemies = 0;

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
    }
    //when player interacts with collider, msg will appear
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            mr.enabled = false;

        }
    }
    public void EnemyKillCounter(int number)
    {
        numberOfEnemies += number;
        if (numberOfEnemies >= 12)
        {
            SceneManager.LoadScene("Act 2 Level 2");

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
