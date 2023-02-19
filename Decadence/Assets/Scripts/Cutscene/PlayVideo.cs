using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour
{
    [Header("Scene")]
    public string sceneToLoad;
    public bool ifVideoIsSeparateScene = true;
    [Header("Frame")]
    public float frameCount;
    public float frame;
    public float frameOffset = 4f;
    [Header("Allow Skipping")]
    public bool allowSkipping = false;
    public bool immediateTransition = false;
    [Header("Fade Away")]
    public bool canFadeAway;

    VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        //casts the frame count to long since this is a ulong
        //frameOffset helps offset since the actual frame that the video is on tends to not end exact
        frameCount = (long)videoPlayer.frameCount - frameOffset;
    }
    // Update is called once per frame
    void Update()
    {
        //this is just a float which increases by the frame number of the video as it plays
        frame = videoPlayer.frame;
        if (ifVideoIsSeparateScene)
        {
            //when frame == total frame count, allow player to skip
            if (frame >= frameCount)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
        else
        {
            //if it isnt a separate scene, instantly load the next scene once the video is over
            if (frame >= frameCount)
            {
                if(canFadeAway)
                {
                    StartCoroutine(FadeAway());
                }
            }
        }
        //allows for skipping before the vid ends
        if (allowSkipping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        //if i want the video to immediately transition
        if (immediateTransition && frame >= frameCount)
        {
            //runs the function to immediately transition
            ImmediateTransition();
        }
    }
    //function that immediately loads the scene
    public void ImmediateTransition()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    //Coroutine that waits a bit before loading the scene
    IEnumerator FadeAway()
    {        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
