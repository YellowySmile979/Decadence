using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVideoPlayerToPlay : MonoBehaviour
{
    VideoPlayerTrigger vpt;

    // Start is called before the first frame update
    void Start()
    {
        vpt = FindObjectOfType<VideoPlayerTrigger>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            vpt.playVideo = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
