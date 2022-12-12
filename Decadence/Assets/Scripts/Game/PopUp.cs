using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    MeshRenderer mr;
    public bool thugHasDied = true;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();

    }
    //when player collides with collider, enable the mesh renderer, assuming the thug hasn't died yet
    void OnTriggerEnter2D(Collider2D other)
    {
        //from the code written under void OnTriggerExit2D, if thugHasDied == true, the mesh renderer will turn on as per normal,
        //otherwise the mesh renderer will permanently be set to false
        if (thugHasDied == true)
        {

            if (other.GetComponent<PlayerController>())
            {
                mr.enabled = true;

            }
        }else if (thugHasDied == false)
        {
            mr.enabled = false;

        }
    }
    //when player interacts with collider, msg will appear. if thug dies, msg is PERMANENTLY not able to show up
    void OnTriggerExit2D(Collider2D other)
    {
        //determines if thug has died or not and if he has died, sets the bool to false PERMANENTLY
        if (thugHasDied == true)
        {
            if (other.GetComponent<PlayerController>())
            {
                mr.enabled = false;

            }
            else if (other.GetComponent<HurtPlayer>())
            {
                mr.enabled = false;
                thugHasDied = false;

            }
        }
    }
}
