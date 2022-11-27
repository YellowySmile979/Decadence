using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    FallingPlatformSpawner FPS; 
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FPS = GetComponentInParent<FallingPlatformSpawner>(); 


    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals ("Player"))
        //if collided game object with the platform has the tag "Player" 
        {
            Invoke("DropPlatform", 0.5f);
            //cause a method to occur in seconds 

            Destroy(gameObject, 3f);

            FPS.isplatformThere = false;

            
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false; 
        //kinematic causes rigidbody2d to not affect the gameobject, making it false turns the rigidbody2d on and so it falls 
    }

}