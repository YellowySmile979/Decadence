using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float timeBetweenRespawn = 5f;
    public float firstSpawn = 5f;
    public GameObject whatSpawns;
    public int bulletSpawnCount = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bulletSpawnCount < 5)
        {
            firstSpawn -= Time.deltaTime;
            if (firstSpawn <= 0f)
            {
                Instantiate(whatSpawns, gameObject.transform.position, gameObject.transform.rotation);
                firstSpawn = timeBetweenRespawn;
                bulletSpawnCount += 1;


            }
        }else
        {

        }
    }
}


