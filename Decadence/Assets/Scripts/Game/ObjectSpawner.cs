using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject objectToSpawn;
    float spawnTime;
    public float maxSpawnTime = 10f;
    [Header("Limiters")]
    public bool limitSpawning;
    public int amountOfItemsThatCanSpawn = 3;
    int amountOfItemsThatHasSpawnedCounter;

    GameObject objectStorage; //basically a way to check if we have spawned an object

    // Start is called before the first frame update
    void Start()
    {
        //sets the timer at the start
        spawnTime = maxSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //allows timer to begin ticking down
        if(objectStorage == null) spawnTime -= Time.deltaTime;
        if(limitSpawning) //condition to check if i allowed spawning to be limited
        {
            //checks to see if nothing has spawned, spawntime<=0 so essentially can spawn
            //and checks that the amount of items of spawned is still less than the amount of items
            //that should spawn
            if(objectStorage == null && spawnTime <= 0 && 
                amountOfItemsThatHasSpawnedCounter < amountOfItemsThatCanSpawn)
            {
                //instantiates the item and also stores it so that we can know if it has spawned or not
                objectStorage = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                //resets spawntime
                spawnTime = maxSpawnTime;
                //adds 1 to the item counter
                amountOfItemsThatHasSpawnedCounter++;
            }
        }
        else
        {
            //checks to see if nothing has spawned, spawntime<=0 so essentially can spawn
            if (objectStorage == null && spawnTime <= 0)
            {
                //instantiates the item and also stores it so that we can know if it has spawned or not
                objectStorage = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                //resets spawntime
                spawnTime = maxSpawnTime;
            }
        }
    }
}
