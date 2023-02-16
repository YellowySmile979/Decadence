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
    [Header("Fade Away")]
    public bool canFadeAway;
    public Color fadeColour;
    public float transitionSpeed;

    VideoPlayer videoPlayer;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        sr = GetComponentInChildren<SpriteRenderer>();

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
            if (frame == frameCount)
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
            if (frame == frameCount)
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
    }
    IEnumerator FadeAway()
    {
        while (fadeColour.a < 1)
        {
            fadeColour.a = Mathf.Lerp(0f, 1f, transitionSpeed);
            sr.color = fadeColour;
        }
        print(fadeColour.a);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
