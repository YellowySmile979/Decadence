using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderScript : MonoBehaviour
{

    //LineRenderer lR;

    SpriteRenderer sr;
    BoxCollider2D box;
    Animator anim;
    //calling components

    [Header("Shooting")]
    public LayerMask WhoICanSee;//who the enemy can see
    bool playerSeen;//whether the player is seen
    [HideInInspector] public float TimeForCrouching, RateForCrouching, RateForShooting=2;
    public float time;
    //variables to shooting
    [HideInInspector] public bool canShoot;//whether the enemy can shooting
    public Transform firePoint;//where the bullet is created
    //public float ammo=3;
    public GameObject enemyBullet;//prefab of the bullet
    bool goingToShoot = true;//the enemy is going to shoot
    [Header("Reloading/Ammo")]
    public int AmmoInTheGun;//ammount of ammo in gun
    public int MaxAmmo;//the maximum amount of ammo in gun
    bool IsCrouching;//is crouching
    float timer;//timer
    public float TimeInReloading;//time in reloading
    bool IsReloading;// the enemy is reloading
    [Header("Key")]
    public Transform keySpawnPosition;
    public GameObject key;

    [Header("Health")]
    //[HideInInspector]
    public bool halfHp, lastHp;//at points at which the enemy goes into states

    //public float  crouchedY,  CrouchedOffSetY;
    //[HideInInspector] public float StandingScaleY, StandingOffSetY;

    [HideInInspector] public int maxhp;//max hp for boss
    public int hp = 8;//hp for enemy
    public HealthBarBehaviour HealthBar;//enemy healthbar
    void Start()
    {
        RateForShooting = 2;
        maxhp = hp;//yes
        HealthBar.SetHealth(hp, maxhp);
        //setting hp in ui
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        //calling components
        goingToShoot = false;
        IsCrouching = false;
        IsReloading = false;
        halfHp = false;
        lastHp = false;
        //precaution not necessary
        MaxAmmo = AmmoInTheGun;
    }


    // Update is called once per frame
    void Update()
    {
        /*if (playerSeen == true && ammo==0)
        {
            time = 0;
            followPlayer();
        }
        if (playerSeen == false && canflip == true)
        {
            standby();
        }
        */
        anim.SetBool("IsCrouching", IsCrouching);
        anim.SetBool("HalfHp", halfHp);
        anim.SetBool("LastHp", lastHp);
        anim.SetBool("IsCrouching", IsCrouching);
        HealthBar.SetReload(timer, TimeInReloading);
        //setting the animator
        if (goingToShoot != true && IsReloading==false)
        {
            ChangeCrouchStance();
        }//change crouchstance
        if (playerSeen == true && goingToShoot == false && AmmoInTheGun >= 1)
        {
            StartCoroutine(shootOnSight());//shoot on sight
        }
        else if (AmmoInTheGun <= 0 && !IsReloading && IsCrouching==false )
        {
            IsCrouching = false;
            IsReloading = true;
        }//the enemy is reloading
        if (IsReloading)
        {
            timer += Time.deltaTime;
            if (timer > TimeInReloading)
            {
                IsCrouching = true;
                AmmoInTheGun = MaxAmmo;
                IsReloading = false;
                timer = 0;
            }
        }
    }//reloading timer

    IEnumerator shootOnSight()
    {
        goingToShoot = true;
        anim.SetTrigger("Shooting");

        yield return new WaitForSeconds(RateForShooting);//time
        if (!halfHp || AmmoInTheGun <= 1)
        {
            
            goingToShoot = false;
        }
        else if(halfHp && AmmoInTheGun>=2)
        { 
            anim.SetTrigger("Shooting");
            //set trigger here            
            goingToShoot = false;
        }    //shooting more if less hp

    }

    private void OnTriggerEnter2D(Collider2D other)//sight
    {
        if (other.GetComponent<PlayerController>())
        {
            Vector2 dir = other.transform.position - transform.position;
            float dist = dir.magnitude;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dist, WhoICanSee);
            Debug.DrawRay(transform.position, dir, Color.red);

            if (hit.collider == other)
            {
                print(other.name);
                playerSeen = true;
                RateForCrouching = Random.Range(6f, 8f);
                TimeForCrouching = Time.time + RateForCrouching;
            }
        }
    }//this is just sight of view for the commander

    private void OnTriggerExit2D(Collider2D other)//no longer in sight
    {
        if (other.GetComponent<PlayerController>())
        {
            playerSeen = false;//the player is not seen when it leaves it sight of view
        }
    }

    /*
    private void followPlayer()
    {

        float direction = Mathf.Sign(pc.transform.position.x - transform.position.x);
        rb.velocity = new Vector2(moveSpeed * direction, 0);
    }

    private void standby()
    {
        canflip = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, 1);
    }*/

    void ChangeCrouchStance()
    {
        if (Time.time <= TimeForCrouching) return;
        RateForCrouching = Random.Range(6f, 8f);
        TimeForCrouching = Time.time + RateForCrouching;
        if (IsCrouching == false)
        {
            IsCrouching = true;
        }
        else if (IsCrouching == true)
        {
            IsCrouching = false;
        }
    }
    //timer for crouch stance

    public void TakeDamage(int damage)
    {
        hp -= damage;
        HealthBar.SetHealth(hp, maxhp);
        if (hp <= maxhp / 2)
        {
            RateForShooting = 1;
            halfHp = true;
        }
        if (hp == 1)
        {
            lastHp = true;
        }
        if (hp <= 0)
        {
            Instantiate(key, keySpawnPosition.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }//taking damage and the phases relating to their health
    public void CreatingBullet()
    {
        GameObject p = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
        p.transform.localScale = new Vector3(Mathf.Sign(transform.localScale.x), 1, 1);
        AmmoInTheGun--;
    }//spawns bullet and is referenced in the animator

}
