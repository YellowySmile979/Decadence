using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [Header("Cutscene")]
    public string nextScene;
    public List<Sprite> cutsceneFrames;
    //like the string array concept, it creates a list of options to put in sprites
    public TMP_Text textObject;

    int currentImageIndex;
    int currentTextIndex;
    public string[] cutsceneText;

    Image theImage;
    GameObject theTextbox;
    
        //finds specifically the name

    public PlayableDirector playableDirector;


    // Start is called before the first frame update
    void Start()
    {
        playableDirector = FindObjectOfType<PlayableDirector>();
        theImage = GameObject.Find("Cutscene").GetComponent<Image>();
        theTextbox = GameObject.Find("Textbox");

        //velocity of player's rigidbody


        playableDirector.playOnAwake = false;
        ChangeImage();
        ChangeText();
        playableDirector.Play();


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveToNextCutscene());
        Debug.Log("Coroutine started");
    }

    [HideInInspector]  public IEnumerator MoveToNextCutscene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cutsceneFrames != null && cutsceneFrames.Count > 0)
            {
                if (currentImageIndex < cutsceneFrames.Count - 1)
                //if there are more number of frames than the current frame number
                {
                    currentImageIndex++;
                    ChangeImage();
                    ChangeText();
                }
                else
                {
                    EndCutscene();
                }
            }
        }

        yield return null;
    }

    


    void ChangeImage()
    {
        if (theImage != null)
        {
            Debug.Log("cutsceneFrames: " + cutsceneFrames);
            Debug.Log("currentImageIndex: " + currentImageIndex);
            Debug.Log("theImage: " + theImage);
            theImage.sprite = cutsceneFrames[currentImageIndex];
            //on change image function, sprite renderer's sprite is to change from the current image number/sprite image
            Debug.Log("currentImageIndex: " + currentImageIndex);
        }

    }

    void ChangeText()
    {
        if (cutsceneText!= null && cutsceneText.Length > 0)
        {
            theTextbox.SetActive(true);
            textObject.SetText(cutsceneText[currentTextIndex]);
            textObject.gameObject.SetActive(true);
            Debug.Log("Current text index: " + currentTextIndex);
            
            currentTextIndex++;

            if(currentTextIndex >= cutsceneText.Length)
            {
                currentTextIndex = 0;
            }
        }
        else
        {
            theTextbox.SetActive(false);
            Debug.Log("Textbox disabled");
        }
       
    }

    void EndCutscene()
    {
        playableDirector.Stop();
        textObject.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(nextScene);
    }
}
