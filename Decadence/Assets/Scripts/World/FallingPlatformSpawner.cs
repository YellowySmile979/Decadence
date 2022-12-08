using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformSpawner : MonoBehaviour
{
    public GameObject fallingPlatformPrefab;
    public bool isplatformThere;

    // Start is called before the first frame update
    void Start()
    {
        isplatformThere = true;

    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if platform exists, if not do nothing. otherwise start coroutine SpawnPlatform
        if (!isplatformThere)
        {
            StartCoroutine(SpawnPlatform());
            isplatformThere = true;

        }
        else
        {
            return;
        }
    }
    //waits for awhile before triggering the platform to fall
    public IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(3f);

        GameObject platform = Instantiate(fallingPlatformPrefab, transform.position, transform.rotation);

        Destroy(gameObject, 0.5f);

    }
}
