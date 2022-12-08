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

    public IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(3f);

        GameObject platform = Instantiate(fallingPlatformPrefab, transform.position, transform.rotation);

        Destroy(gameObject, 0.5f);

    }
}
