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
    private bool canReload;
    //Function is to make sure you don't reload twice
    public bool IsReloading { get; private set; }
    //cannot shoot while reloading variable
    bool isReloading;

    [Header("Ammo")]
    public static int currentClip = 6;
    public static int maxClipSize = 6;
    public static int currentAmmo = 0;
    public static int maxAmmoSize = 24;
       
    
    private void Start()
    {
        owner = GetComponentInParent<PlayerController>(); //prevents bullet from killing player
        Lm = FindObjectOfType<LevelManager>();
        canReload = true;
    }
    
    public void Fires()
    {
        //prevents firing when player has no ammo
        if (currentClip > 0)
        {
            //instantiates a bullet from prefab
            GameObject bullet = Instantiate(bulletPrefab, FireOffset.position, FireOffset.rotation); 
            //calls the projectile script
            Projectile p = bullet.GetComponent<Projectile>();
            //to change the orientation of the bullet in relation to the player
            bullet.transform.localScale = new Vector3(Mathf.Sign(owner.transform.localScale.x), 1, 1);
            currentClip--;
            Lm.UpdateAmmoMeter();
            owner.ammoUIText.text = " Max Ammo: " + currentAmmo + "/" + maxAmmoSize;
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
            isReloading = true;
            int reloadAmount = maxClipSize - currentClip;//how many bullets to reload
            
            for (int i = 0; i < reloadAmount; i++)
            {
                if (currentClip <= maxClipSize && isReloading == true)
                {
                    owner.ReloadingAnimation(isReloading);
                }
                //reloading part
                if (currentAmmo > 0)
                {
                    currentClip++;
                    currentAmmo--;
                    owner.ammoUIText.text = " Max Ammo: " + currentAmmo + "/" + maxAmmoSize;
                    Lm.UpdateAmmoMeter();
                    yield return new WaitForSeconds(timeBetweenEachBulletReload);
                    //This will keep running until your gun is fully reloaded
                    //also stops u from moving
                }               
            }
            if (currentClip >= 5)
            {
                isReloading = false;
                owner.ReloadingAnimation(isReloading);
            }
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
