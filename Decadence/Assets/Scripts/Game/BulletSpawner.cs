using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float timeBetweenRespawn = 30f; //sets how long it takes for a bullet spawn
    public float firstSpawn = 30f; //determines when a bullet should spawn
    
    public int bulletSpawnCount = 0; //counts how many bullets have spawned
    public int maxBulletSpawnCount = 3; //sets the maximum limit of bullets that is allowed spawn

    public GameObject whatSpawns; //determines what we spawn 

    // Update is called once per frame
    void Update()
    {
        //spawns a bullet only IF there is less than the limit set by the maxBulletSpawnCount
        if (bulletSpawnCount < maxBulletSpawnCount)
        {
            firstSpawn -= Time.deltaTime; //essentially is how the timer decreases
            //when the timer runs out, create a bullet, increase the spawn timer, resets the time limit to the set time
            //and increases the counter
            if (firstSpawn <= 0f)
            {
                //creates bullet
                Instantiate(whatSpawns, gameObject.transform.position, gameObject.transform.rotation);
                //increases the time to respawn
                timeBetweenRespawn += 5f;
                //resets the spawn timer
                firstSpawn = timeBetweenRespawn;
                //increases the count so that once the limit has been hit, bullets stop spawning
                bulletSpawnCount += 1;


            }
        }
        
            
        
    }
    //resets the code so that the bullets can spawn again when the player picks up the bullets
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            bulletSpawnCount = 0; //resets the counter back to zero
            firstSpawn = 30; //resets the timer
            timeBetweenRespawn = 30; //resets the length between the spawning of each bullet

        }
    }
}


