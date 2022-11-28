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
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenEachDamage)
        {
            damageFromSpike = true;
            timer = 0;

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (damageFromSpike == true)
            {
                levelmanager.HurtPlayer(damageToGive);
                damageFromSpike = false;
            }

        }
    }
}
