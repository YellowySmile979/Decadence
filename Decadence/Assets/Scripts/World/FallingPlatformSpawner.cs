using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformSpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject fallingPlatformPrefab;
    public float maxSpawnTime = 10f;
    float spawnTime;

    GameObject storedPlatform;

    // Start is called before the first frame update
    void Start()
    {
        //instantiates the platform at the start of play
        storedPlatform = Instantiate(fallingPlatformPrefab, transform.position, Quaternion.identity);
        //sets timer to max timer
        spawnTime = maxSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //allows timer to tickdown
        spawnTime -= Time.deltaTime;
        //checks to see if a platform has spawned and spawn time is 
        if(storedPlatform == null && spawnTime <= 0)
        {
            //instantiates the falling platform and also stores it so that we know if it has spawned or not
            storedPlatform = Instantiate(fallingPlatformPrefab, transform.position, Quaternion.identity);
            //resets spawn timer
            spawnTime = maxSpawnTime;
        }
    }
}
