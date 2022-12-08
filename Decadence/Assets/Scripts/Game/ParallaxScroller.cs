using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{ 
    SpriteRenderer sr;
    public float x = 0f;
    public Camera thisCamera; 

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
    }
    public float parallax;


    // Update is called once per frame
    void LateUpdate()
    {
        //performs the parallax effect
        float fullWidth = sr.size.x / 2f;
        x = Mathf.Floor((thisCamera.transform.position.x * parallax) / fullWidth) * fullWidth;
        Vector2 newPos = new Vector2((thisCamera.transform.position.x * parallax) + x, thisCamera.transform.position.y * parallax);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
