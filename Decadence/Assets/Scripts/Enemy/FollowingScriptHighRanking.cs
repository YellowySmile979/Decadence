using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingScriptHighRanking : MonoBehaviour
{
    public float moveSpeed = 3f; //sets how fast the enemy moves

    Rigidbody2D rb;
    SpriteRenderer sr;
    PlayerController pc;

    public LayerMask WhoICanSee;//pls put player,default, ground,enemy(if have)
    bool playerSeen;//whether the enemy see the player
    public float time;//time for timer
    public float timeToFlip;//whether the enemy should flip the localScale.x
    public bool canflip;
    public Transform firePoint;
    public float ammo = 3;
    public GameObject enemyBullet;
    public bool goingToShoot;//the enemy is going to shoot
    public LayerMask whatCanBeShot;//pls put default,ground, enemy(if have)
    LineRenderer lR;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        pc = FindObjectOfType<PlayerController>();
        lR = GetComponent<LineRenderer>();
        lR.enabled = false;
        //disable the aiming line

        goingToShoot = false;//to make it the enemy shoot once every few seconds
    }


    // Update is called once per frame
    void Update()
    {

        if (playerSeen == true && ammo == 0)//if the enemy have no ammo and it sees the player, it will follow the player
        {
            time = 0;//restart the timer for flipping
            followPlayer();
        }
        if (playerSeen == false && canflip == true)//if it does not sees the player and can flip, it will flip its localScale
        {
            standby();
        }
        if (canflip == false && playerSeen == false)//the cooldown of flipping the enemy's localScale.x
        {
            timer();
        }
        if (playerSeen == true && ammo > 0 && goingToShoot == false)
        {
            time = 0;//restart the timer for flipping
            StartCoroutine(shootOnSight());
        }
    }

    IEnumerator shootOnSight()
    {
        goingToShoot = true;
        //to make it the enemy shoot once every few seconds
        lR.enabled = true;
        //Enable the aiming line
        Vector2 endPoint = firePoint.position + Vector3.right * 300 * Mathf.Sign(transform.localScale.x);
        //this is to make the line a straight horizontal line
        RaycastHit2D hit = Physics2D.Linecast(firePoint.position, endPoint, whatCanBeShot);
        //fire out a linecast and get back the object that the line collides with

        lR.SetPosition(0, hit.point);
        lR.SetPosition(1, firePoint.position);
        //where the line starts and end
        yield return new WaitForSeconds(3);//wait for 3 seconds
        GameObject p = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
        //create a bullet
        lR.enabled = false;
        p.transform.localScale = new Vector3(Mathf.Sign(firePoint.localScale.x), 1, 1);
        //ensure the bullet goes to the right direction
        ammo--;
        //decrease the ammo count of enemy
        goingToShoot = false;
        //allows the enemy shoot once more if they have bullets
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())//if the enemy see the player
        {
            Vector2 dir = other.transform.position - transform.position;
            //direction from the enemy to the player
            float dist = dir.magnitude;
            //distance from the enemy to the player
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dist, WhoICanSee);
            //raycast to shoot out an invisible beam that once collides with a collider will get back the collider value

            if (hit.collider == other)//if the beam hits the player
            {
                playerSeen = true;//it sees the player
            }
            else if (hit.collider != other)//if the beam does not hit the player
            {
                playerSeen = false;//it does not see the player

            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        playerSeen = false;//the enemy stop seeing the player once they are out of range
    }

    private void followPlayer()//it follows the player
    {

        float direction = Mathf.Sign(pc.transform.position.x - transform.position.x);
        //the direction from the enemy to the player
        rb.velocity = new Vector2(moveSpeed * direction, 0);
        //move toward the player
    }
    private void standby()
    {
        canflip = false;//cooldown
        transform.localScale = new Vector2(transform.localScale.x * -1, 1);//flip the localScale

    }

    private void timer()//it is a timer for flipping, what else do you expect
    {
        time += Time.deltaTime;

        if (time >= timeToFlip)
        {
            canflip = true;
            time = 0;
        }

    }
}
