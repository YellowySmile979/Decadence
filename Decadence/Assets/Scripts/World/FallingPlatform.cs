using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [Header("Shaking")]
    public float shakeSpeed = 0.3f;
    public float shakeTime = 1f;
    Vector2 origin;

    Rigidbody2D rb;
    BoxCollider2D bxCollider;
    EdgeCollider2D ec;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ec = GetComponent<EdgeCollider2D>();
        bxCollider = GetComponent<BoxCollider2D>();
        //stores the original position (minus shakespeed so that platform moves completely from left to right)
        origin = new Vector2(transform.position.x - shakeSpeed, transform.position.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //checks to see if collided game object with the platform has the tag "Player"
        if (collision.gameObject.tag.Equals("Player"))        
        {
            StartCoroutine(FallingPlatformCo());       
        }
    }
    //Coroutine that handles the platform falling
    IEnumerator FallingPlatformCo()
    {
        float t = 0;
        //platform shakes until the loop completes as determined by t
        while(t < shakeTime)
        {
            //makes the platform move between two set positions
            transform.position = new Vector2(origin.x + Mathf.PingPong(Time.time, shakeSpeed * 2), origin.y);
            yield return new WaitForEndOfFrame();
            //increases t by time.deltaTime so that the loop will eventually end
            t += Time.deltaTime;
        }        
        //kinematic causes rigidbody2d to not affect the gameobject,
        //making it false turns the rigidbody2d on and so it falls
        rb.isKinematic = false;
        ec.enabled = false; //disables edge collider
        bxCollider.enabled = false; //disables box collider
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject, 3f);
    }
}
