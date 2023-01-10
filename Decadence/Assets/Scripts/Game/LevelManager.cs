using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Respawn")]
    public float waitToRespawn = 2f;
    PlayerController player;

    [Header("Health")]
    public int maxHealth;
    public int healthCount;    
    public int healthToRespawn;
    int maxHealthCount = 10;

    bool respawning;

    [Header("Hearts")]
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;
    public Image heart6;
    public Image heart7;
    public Image heart8;
    public Image heart9;
    public Image heart10;
    public Image heart11;

    [Header("Ammo")]
    public Image Ammo;

    public Sprite Ammo0;
    public Sprite Ammo1;
    public Sprite Ammo2;
    public Sprite Ammo3;
    public Sprite Ammo4;
    public Sprite Ammo5;
    public Sprite Ammo6;

    [Header("Effect")]
    public GameObject deathSplosion;

    [Header("Damage Boost")]
    public Image damageBoost;
    public Text numberOfCrumpets;
    int crumpets = 0;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        healthToRespawn = healthCount;
        //healthCount = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    public void AddCrumpets(int amount)
    {
        crumpets += amount;
        numberOfCrumpets.text = "x" + crumpets;
        player.NumberOfCrumpetsTracker(crumpets);
    }
    public void UpdateCrumpetUI(float fillAmount)
    {
        if (fillAmount <= 0) damageBoost.enabled = false;
        if (fillAmount > 0) damageBoost.enabled = true;
        //clamp caps the fillAmount between the two min-max values in this case 0-1
        damageBoost.fillAmount = Mathf.Clamp(fillAmount, 0, 1);
    }

    //when health is below zero or zero, respawn the character
    private void Update()
    {
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }

    }
    //starts the coroutine RespawnCO()
    public void Respawn()
    {
        StartCoroutine(RespawnCO());
    }

    //coroutine RespawnCO() is created here
    IEnumerator RespawnCO()
    {
        //Diasble the player
        player.gameObject.SetActive(false);

        //creates the objects particles when player dies
        Instantiate(deathSplosion, player.transform.position, player.transform.rotation);

        //wait for a while
        yield return new WaitForSeconds(waitToRespawn);



        //moveplayer to respawn position
        player.gameObject.SetActive(true);
        player.transform.position = player.respawnPosition;
        healthCount = healthToRespawn;
        respawning = false;
        UpdateHeartMeter();
        UpdateAmmoMeter();
    }

    //how much damage the player should take
    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
        UpdateHeartMeter();
        UpdateAmmoMeter();
    }
    //heals player
    public void HealPlayer(int health)
    {
        healthCount += health;
        UpdateHeartMeter();

    }
    //updates the health sprite
    public void UpdateHeartMeter()
    {


        if (healthCount >= 10)
        {
            healthCount = maxHealthCount; //limits the max health to 10

            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(true);
            heart6.gameObject.SetActive(true);
            heart7.gameObject.SetActive(true);
            heart8.gameObject.SetActive(true);
            heart9.gameObject.SetActive(true);
            heart10.gameObject.SetActive(true);
            heart11.gameObject.SetActive(true);

        }
        else if (healthCount >= 9)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(true);
            heart6.gameObject.SetActive(true);
            heart7.gameObject.SetActive(true);
            heart8.gameObject.SetActive(true);
            heart9.gameObject.SetActive(true);
            heart10.gameObject.SetActive(true);
            heart11.gameObject.SetActive(false);
        }
        else if (healthCount >= 8)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(true);
            heart6.gameObject.SetActive(true);
            heart7.gameObject.SetActive(true);
            heart8.gameObject.SetActive(true);
            heart9.gameObject.SetActive(true);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);

        }
        else if (healthCount >= 7)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(true);
            heart6.gameObject.SetActive(true);
            heart7.gameObject.SetActive(true);
            heart8.gameObject.SetActive(true);
            heart9.gameObject.SetActive(false);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);
        }
        else if (healthCount >= 6)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(true);
            heart6.gameObject.SetActive(true);
            heart7.gameObject.SetActive(true);
            heart8.gameObject.SetActive(false);
            heart9.gameObject.SetActive(false);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);
        }
        else if (healthCount >= 5)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(true);
            heart6.gameObject.SetActive(true);
            heart7.gameObject.SetActive(false);
            heart8.gameObject.SetActive(false);
            heart9.gameObject.SetActive(false);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);
        }
        else if (healthCount >= 4)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(true);
            heart6.gameObject.SetActive(false);
            heart7.gameObject.SetActive(false);
            heart8.gameObject.SetActive(false);
            heart9.gameObject.SetActive(false);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);
        }
        else if (healthCount >= 3)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(false);
            heart6.gameObject.SetActive(false);
            heart7.gameObject.SetActive(false);
            heart8.gameObject.SetActive(false);
            heart9.gameObject.SetActive(false);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);
        }
        else if (healthCount >= 2)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(false);
            heart5.gameObject.SetActive(false);
            heart6.gameObject.SetActive(false);
            heart7.gameObject.SetActive(false);
            heart8.gameObject.SetActive(false);
            heart9.gameObject.SetActive(false);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);
        }
        else if (healthCount >= 1)
        {
            heart1.color = new Color(255, 255, 255, 255);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart5.gameObject.SetActive(false);
            heart6.gameObject.SetActive(false);
            heart7.gameObject.SetActive(false);
            heart8.gameObject.SetActive(false);
            heart9.gameObject.SetActive(false);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);
        }
        else
        {
            heart1.color = new Color(0, 0, 0, 255);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart5.gameObject.SetActive(false);
            heart6.gameObject.SetActive(false);
            heart7.gameObject.SetActive(false);
            heart8.gameObject.SetActive(false);
            heart9.gameObject.SetActive(false);
            heart10.gameObject.SetActive(false);
            heart11.gameObject.SetActive(false);

        }
    }
    //updates the ammo counter
    public void UpdateAmmoMeter()
    {
        switch (Weapon.currentClip)
        {
            case 0:
                Ammo.sprite = Ammo0;
                break;
            case 1:
                Ammo.sprite = Ammo1;
                break;
            case 2:
                Ammo.sprite = Ammo2;
                break;
            case 3:
                Ammo.sprite = Ammo3;
                break;
            case 4:
                Ammo.sprite = Ammo4;
                break;
            case 5:
                Ammo.sprite = Ammo5;
                break;
            case 6:
                Ammo.sprite = Ammo6;
                break;
            default:
                Ammo.sprite = Ammo0;
                break;
        }
    }
}
