using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletspeed = 5f;
    float direction = 1;
    public float lifespan = 3f;

    private void Start()
    {
        direction = Mathf.Sign(transform.localScale.x);
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * direction * Time.deltaTime * bulletspeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
