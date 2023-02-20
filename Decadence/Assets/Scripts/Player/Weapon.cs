using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Reload")]
    public GameObject bulletPrefab;
    public Transform FireOffset;
    PlayerController owner;
    LevelManager Lm;
    public float timeBetweenEachBulletReload;
    [HideInInspector]public bool canReload;
    //Function is to make sure you don't reload twice
    public bool IsReloading { get; private set; }
    //cannot shoot while reloading variable
    public bool reloading;
    public float waitToReload;
    public int reloadCount = 0;

    [Header("Ammo")]
    public static int currentClip = 6;
    public static int maxClipSize = 6;
    public static int currentAmmo = 0;
    public static int maxAmmoSize = 24;

    [Header("Particles")]
    public GameObject muzzleFlash;

    [Header("SFX")]
    public AudioClip emptyClipSound;
    public AudioClip revolverShootingSound;
    public AudioClip reloadingSoundOne;
    public AudioClip reloadingSoundTwo;
    public AudioClip rackingRevolverSound;
    int randomSound;
    AudioSource audioSource;
    
    private void Start()
    {
        owner = GetComponentInParent<PlayerController>(); //prevents bullet from killing player
        Lm = FindObjectOfType<LevelManager>();
        audioSource = GetComponent<AudioSource>();
        canReload = true;
    }
    //plays empty clip sound
    public void PlayEmptyGunSound()
    {
        audioSource.PlayOneShot(emptyClipSound);
    }
    //plays the sound of the revolver fire
    public void PlayRevolverShootingNoise()
    {
        audioSource.PlayOneShot(revolverShootingSound);
    }
    //function performs the action of firing the reolver
    public void Fires()
    {
        //prevents firing when player has no ammo
        if (currentClip > 0)
        {
            //instantiates a bullet from prefab
            GameObject bullet = Instantiate(bulletPrefab, FireOffset.position, FireOffset.rotation);           
            GameObject flash;
            if (owner.transform.localScale.x == 1) 
            {
                //instantiates the muzzle flash to where you fire from
                flash = Instantiate(muzzleFlash, FireOffset.position, Quaternion.Euler(0, 90, 0));
                Destroy(flash, 1.2f);
            }            
            else if (owner.transform.localScale.x == -1)
            {
                //to change the orientation of the muzzle flash in relation to the player
                flash = Instantiate(muzzleFlash, FireOffset.position, Quaternion.Euler(180, 90, 0));
                Destroy(flash, 1.2f);
            }
            //plays noise after flash
            PlayRevolverShootingNoise();
            //calls the projectile script
            Projectile p = bullet.GetComponent<Projectile>();
            //to change the orientation of the bullet in relation to the player
            bullet.transform.localScale = new Vector3(Mathf.Sign(owner.transform.localScale.x), 1, 1);
            currentClip--;
            Lm.UpdateAmmoMeter();
            owner.ammoUIText.text = "" + currentAmmo;           
        }
        else
        {
            PlayEmptyGunSound(); //calls the function when currentclip posses 0 bullets
        }

    }
    //script for reloading gun
    public IEnumerator Reload()
    {
        //checks to see if you can reload based on if player has ammo in reserve
        if (canReload)
        {
            owner.canMove = false;
            canReload = false;
            IsReloading = true;
            reloading = true;
            int reloadAmount = maxClipSize - currentClip;//how many bullets to reload
            
            for (int i = 0; i < reloadAmount; i++)
            {
                //reloading part
                if (currentAmmo > 0)
                {
                  
                    randomSound = Random.Range(0, 1); //randomises reload sound
                    currentClip++; //adds 1 to currentClip
                    currentAmmo--; //minuses 1 to currentAmmo
                    reloadCount++; //adds 1 to reloadCount
                    //updates the ammo UI to display the text
                    owner.ammoUIText.text = "" + currentAmmo;
                    //updates the ammo UI
                    Lm.UpdateAmmoMeter();
                    //if the amount of ammo still in the barrel less than the max the barrel can hold
                    //and player is reloading
                    if (currentClip <= maxClipSize && reloading == true)
                    {

                        //starts the reloading animation
                        owner.ReloadingAnimation(reloading);
                        //randomises the reloading noise
                        if(randomSound == 0)
                        {
                            audioSource.PlayOneShot(reloadingSoundOne);
                        }
                        else
                        {
                            audioSource.PlayOneShot(reloadingSoundTwo);
                        }
                    }
                    //when reload is done, wait a bit to allow reload anim to end then stop reloading
                    //by updating the function that handles the bool that controls reloading
                    //samething if current ammo is not
                    if (reloadCount == reloadAmount)
                    {
                        yield return new WaitForSeconds(waitToReload);
                        reloading = false;
                        owner.ReloadingAnimation(reloading);
                    }
                    else if(currentAmmo <= 0)
                    {
                        yield return new WaitForSeconds(waitToReload);
                        reloading = false;
                        owner.ReloadingAnimation(reloading);
                    }
                    //once reloading is done, play this sound
                    if (reloading == false) audioSource.PlayOneShot(rackingRevolverSound);
                    yield return new WaitForSeconds(timeBetweenEachBulletReload);
                    //This will keep running until your gun is fully reloaded
                    //also stops u from moving                   
                }               
            }           
            reloadCount = 0;
            canReload = true;
            IsReloading = false;
            //reloadAmmount = (currentAmmo - reloadAmmount) >= 0 ? reloadAmmount : currentAmmo;
            //currentClip += reloadAmmount;
            //currentAmmo -= reloadAmmount;

            owner.canMove = true;
        }

    }
    //adds ammo to the current clip
    public void AddAmmo(int amount)
    {
        currentAmmo += amount; //adds currentAmmo by the added amount under BulletCollecting script
        Lm.UpdateAmmoMeter();
        owner.ammoUIText.text = "" + currentAmmo;
        if (currentAmmo >= maxAmmoSize) //prevents stack overflow
        {
            currentAmmo = maxAmmoSize; //to limit the ammo count
            Lm.UpdateAmmoMeter();
            owner.ammoUIText.text = "" + currentAmmo;
        }
    }
    public void ReloadingDeath()
    {
        print("death");
        reloadCount = 0;
        canReload = true;
        IsReloading = false;
        reloading = false;
        owner.ReloadingAnimation(reloading);
        //reloadAmmount = (currentAmmo - reloadAmmount) >= 0 ? reloadAmmount : currentAmmo;
        //currentClip += reloadAmmount;
        //currentAmmo -= reloadAmmount;

        owner.canMove = true;
    }
}
