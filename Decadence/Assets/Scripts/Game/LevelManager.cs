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
    public static int healthCount = 1;    
    public int healthToRespawn;
    int maxHealthCount = 10;
    [HideInInspector] public int healthTracker;

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

    [Header("Death Effect")]
    public GameObject deathSplosion;
    public AudioClip deathSound;
    [HideInInspector] public AudioSource audioSource;

    [Header("Damage Boost")]
    public Image damageBoost;
    public Text numberOfCrumpets;
    int crumpets = 0;
    bool usingPowerUp = false;
    PowerUpParticles powerUpParticles;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        powerUpParticles = FindObjectOfType<PowerUpParticles>();
        healthToRespawn = healthCount;
        numberOfCrumpets.text = "x" + 0;
        //healthCount = maxHealth;
    }
    //updates the UI for the crumpets when someone picks up a crumpets
    public void AddCrumpets(int amount)
    {
        crumpets += amount;
        player.NumberOfCrumpetsTracker(crumpets); //updates the crumpet tracker
        if (crumpets >= 0)
        {
            numberOfCrumpets.text = "x" + crumpets;
        }
    }
    //updates the timer for the power up
    public void UpdateCrumpetUI(float fillAmount)
    {
        //if the fill is empty, disable the power up
        if (fillAmount <= 0)
        {
            damageBoost.enabled = false;
            usingPowerUp = false;
        }
        //if the fill still is filled, power up is still active
        if (fillAmount > 0)
        {
            damageBoost.enabled = true;
            usingPowerUp = true;
            //power up particles activate
            if (usingPowerUp) powerUpParticles.PlayPowerUpParticles();
        }
        //clamp caps the fillAmount between the two min-max values in this case 0-1
        damageBoost.fillAmount = Mathf.Clamp(fillAmount, 0, 1); //restricts the value to between 0-1 for radial
    }

    //when health is below zero or zero, respawn the character
    private void Update()
    {
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
        healthTracker = healthCount;
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
        //plays this sound when player dies
        audioSource.PlayOneShot(deathSound);

        //wait for a while
        yield return new WaitForSeconds(waitToRespawn);

        //moveplayer to respawn position
        player.gameObject.SetActive(true);
        player.transform.position = player.respawnPosition;
        healthCount = healthToRespawn;
        respawning = false;
        powerUpParticles.StopPowerUpParticles();
        UpdateHeartMeter();
        UpdateAmmoMeter();
    }

    //how much damage the player should take
    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
        UpdateHeartMeter();
        UpdateAmmoMeter();
        StartCoroutine(player.ChangeColour());
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
