using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite lampOn; //so that we can determine what the sprite will switch to

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    //switches the lamp sprite to the lampOn one
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            sr.sprite = lampOn;

        }
    }
}
