using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletspeed = 5f;
    float direction = 1;
    public float lifespan = 3f;
    public int damage = 1;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
