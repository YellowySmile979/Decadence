using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlayerTrigger : MonoBehaviour
{
    public GameObject vidPlayer;
    public string sceneToLoad;
    public GameObject canvas;
    [HideInInspector] public bool playVideo = false;

    PlayerController player;
    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lm = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //when player triggers this object, play video, stop player from moving, turn off bgm and canvas
        if (collision.GetComponent<PlayerController>() && playVideo)
        {
            vidPlayer.SetActive(true);
            player.canMove = false;
            player.Reboot();
            lm.audioSource.Stop();
            player.audioSource.Stop();
            canvas.SetActive(false);

            //allows for skipping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
