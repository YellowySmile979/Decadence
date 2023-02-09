using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerBeerShards : MonoBehaviour
{
    LevelManager levelmanager;
    public int damageToGive = 1;
    private bool damageFromSpike;
    public float timeBetweenEachDamage = 2f;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        levelmanager = FindObjectOfType<LevelManager>();
        damageFromSpike = false;
    }
    private void Update()
    {
        if (damageFromSpike)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenEachDamage)
            {
                levelmanager.HurtPlayer(damageToGive);
                timer = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            damageFromSpike = true;

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            damageFromSpike = false;
        }
    }
}
