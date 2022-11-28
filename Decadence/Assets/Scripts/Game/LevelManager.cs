using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn = 2f;
    PlayerController player;

    
    public int maxHealth;
    public int healthCount;

    bool respawning;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite heartFull;
    public Sprite heartEmpty;

    public GameObject deathSplosion;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        healthCount = maxHealth;

    }

    private void Update()
    {
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }

    }
    public void Respawn()
    {
        StartCoroutine(RespawnCO());
    }

    IEnumerator RespawnCO()
    {
        //Diasble the player
        player.gameObject.SetActive(false);
        //wait for a while
        yield return new WaitForSeconds(waitToRespawn);
        //creates the objects particles when player dies
        Instantiate(deathSplosion, player.transform.position, player.transform.rotation);


        //moveplayer to respawn position
        player.gameObject.SetActive(true);
        player.transform.position = player.respawnPosition;
        healthCount = maxHealth;
        respawning = false;
        UpdateHeartMeter();
    }

    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
        UpdateHeartMeter();
    }
    public void UpdateHeartMeter()
    {
        switch (healthCount)
        {
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }
}
