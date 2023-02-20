using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject doorClosed, doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<PlayerController>())
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
        }
    }
}
