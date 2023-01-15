using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCrate : MonoBehaviour
{
    //for us to define what is loot, how much of it to drop and where to spawn it
    [Header("Loot")]
    public GameObject lootToDrop;
    public Transform whereToSpawnLoot;
    public int maxLoot;
    int numberOfLoot;

    //This to determine when the box has touched the ground so that the box can break
    [Header("Ground Check")]
    public Transform groundCheck;
    //transform creates an option or component under Inspector to get the Transform of a gameobject
    public float groundCheckRadius = 0.4f;
    public LayerMask whatIsGround;

    bool isGrounded;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //randomises loot
        maxLoot = Random.Range(0, 3);
    }
    
    // Update is called once per frame
    void Update()
    {
        //if i draw a circle, is there a collider in there? thats what this is
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //checks to see if box has touched the ground, if it has, destroy the block BUT wait a short while to spawn bullets
        //based on the amount we have specified in maxLoot
        if(isGrounded)
        {
           Destroy(gameObject,0.4f); 
            if (numberOfLoot < maxLoot)
            {
                Instantiate(lootToDrop, whereToSpawnLoot.position, whereToSpawnLoot.rotation);
                numberOfLoot += 1;
                             
            } 
        }
    }
     public void DropBoxOrChain()
    {
        rb.isKinematic = false;
    }
    
}
