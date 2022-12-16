using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act2Lvl2PopUp : MonoBehaviour
{
    bool boxHasFallen;

    MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            mr.enabled = true;

        }else if(boxHasFallen == false)
        {
            mr.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            mr.enabled = false;

        }else if(collision.GetComponent<FallingCrate>())
        {
            mr.enabled = false;
            boxHasFallen = false;
        }
    }
}
