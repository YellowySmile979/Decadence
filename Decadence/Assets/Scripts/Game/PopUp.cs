using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
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
}
