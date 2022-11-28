using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform FireOffset;
    PlayerController owner;
    public float timeBetweenEachBulletReload;
    private bool canReload;
    //Function is to make sure you don't reload twice
    public bool IsReloading { get; private set; }
    //cannot shoot while reloading variable


    public int currentClip, maxClipSize, currentAmmo, maxAmmoSize;

    private void Start()
    {
        owner = GetComponentInParent<PlayerController>();
        canReload = true;
    }

    public void Fires()
    {
        if (currentClip > 0)
        {

            GameObject bullet = Instantiate(bulletPrefab, FireOffset.position, FireOffset.rotation);
            Projectile p = bullet.GetComponent<Projectile>();
            bullet.transform.localScale = new Vector3(Mathf.Sign(owner.transform.localScale.x), 1, 1);
            currentClip--;
        }

    }
    public IEnumerator Reload()
    {
        if (canReload)
        {
            owner.canMove = false;
            canReload = false;
            IsReloading = true;
            int reloadAmount = maxClipSize - currentClip;//how many bullets to reload
            for (int i = 0; i < reloadAmount; i++)
            {
                currentClip++;
                currentAmmo--;
                yield return new WaitForSeconds(timeBetweenEachBulletReload);
                // This will keep running until your gun is fully reloaded

            }

            canReload = true;
            IsReloading = false;
            //reloadAmmount = (currentAmmo - reloadAmmount) >= 0 ? reloadAmmount : currentAmmo;
            //currentClip += reloadAmmount;
            //currentAmmo -= reloadAmmount;

            owner.canMove = true;
        }

    }

    public void addAmmo(int ammoAmmounnt)
    {
        currentAmmo += ammoAmmounnt;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }
}
