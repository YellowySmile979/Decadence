using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    BossLevelExit bossLevelExit;

    //when player picks up key, set the door to be able to be opened
    //then destroy the key
    void OnTriggerEnter2D(Collider2D collision)
    {
        bossLevelExit.hasKey = true;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        bossLevelExit = FindObjectOfType<BossLevelExit>();
    }
}
