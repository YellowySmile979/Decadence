using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tea : MonoBehaviour
{
    //sets how much health to give player
    public int maxHealthToGive = 5;
    int healthToGive;

    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();

    }
    //when player collides with tea collider, heal player by health to give and then destroy the object
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            healthToGive = maxHealthToGive;
            lm.HealPlayer(healthToGive);
            Destroy(gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}
