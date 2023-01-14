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
    bool canReload;
    //Function is to make sure you don't reload twice
    public bool IsReloading { get; private set; }
    //cannot shoot while reloading variable
    bool reloading;
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
            owner.ammoUIText.text = " Max Ammo: " + currentAmmo + "/" + maxAmmoSize;           
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
                    currentClip++;
                    currentAmmo--;
                    reloadCount++;
                    owner.ammoUIText.text = " Max Ammo: " + currentAmmo + "/" + maxAmmoSize;
                    Lm.UpdateAmmoMeter();
                    if (currentClip <= maxClipSize && reloading == true)
                    {
                        owner.ReloadingAnimation(reloading);
                    }
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
        owner.ammoUIText.text = " Max Ammo: " + currentAmmo + "/" + maxAmmoSize;
        if (currentAmmo >= maxAmmoSize) //prevents stack overflow
        {
            currentAmmo = maxAmmoSize; //to limit the ammo count
            Lm.UpdateAmmoMeter();
            owner.ammoUIText.text = " Max Ammo: " + currentAmmo + "/" + maxAmmoSize;
        }
    }
}
