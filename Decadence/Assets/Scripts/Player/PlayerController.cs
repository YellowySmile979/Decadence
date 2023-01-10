using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5; //float is for things like speed, vectors etc.
    public float jumpSpeed = 7; //float is a decimal no.

    [Header("Ground Check")]
    public Transform groundCheck;
    //transform creates an option or component under Inspector to get the Transform of a gameobject
    public float groundCheckRadius = 0.4f;
    public LayerMask whatIsGround;


    //rb is variable name that we have to declare and will be defined later
    Rigidbody2D rb;
    Animator anim;
    bool isGrounded;
    Weapon weapon;
    LevelManager LM;

    [Header("Damage")]
    public int damg = 1;

    [Header("Firing Time")]
    private bool canFire;
    private float timer;
    public float timeBetweenFiring;
    private bool canreload;
    
    [HideInInspector] public bool canMove = true;
    [HideInInspector] public Vector2 respawnPosition;

    [Header("UI")]
    public Text ammoUIText;

    // Start is called before the first frame update
    void Start()
    {
        //for script to take the labelled component under Inspector
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weapon = GetComponentInChildren<Weapon>();
        respawnPosition = transform.position;
        LM = FindObjectOfType<LevelManager>();

        //updates the UI for ammo
        ammoUIText.text = " Max Ammo: " + Weapon.currentAmmo + "/" + Weapon.maxAmmoSize;
        LM.UpdateHeartMeter();
        LM.UpdateAmmoMeter();
    }

    // Update is called once per frame
    void Update()
    {
        //if i draw a circle, is there a collider in there? thats what this is
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //to activate animations' variables
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
        if (canMove) movement();


        

    }
    public void SetDamage(int dmg)
    {
        damg = dmg;
    }
    //references movement
    void movement()
    {

        //if command basically is if 1 can happen, 1 happens, else 2. otherwise 3 etc etc
        //listens to the left and right or A and D keys, and moves the player when keys are pressed
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //'new' is used for Vectors
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y); //moves object to the right constantly

            //transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
            //delta time is the time between 2 frames (last and current),
            //this line of code above is to control speed better, assuming frame rate=30,
            //Time.deltaTime=1/30=0.03(all approx)
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); //moves it other direction
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //straight up stops her from moving when i dont input anything
        }

        //listen to spacebar to jump
        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpSpeed)
            //above is what the slides say

            rb.velocity += new Vector2(0, jumpSpeed); //this is much more efficient

            //basically it forms a vector triangle which adds the x axis velocity with the y axis velocity to produce
            //the third velocity which is diagonal (basically physics)
        }

        //checks to see if you can fire
        if (!canFire)
        {
            timer += Time.deltaTime;
            //checks to see if timer > timeBetweenFiring, if yes then player can fire and timer is set to zero
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }

        }

        //Possibly shooting script
        if (Input.GetButtonDown("Fire1") && canFire && !weapon.IsReloading) 
        {
            anim.SetTrigger("Shoot");
            weapon.Fires();
            canFire = false;
            //Projectile bullet = Instantiate(projectilePrefab, FireOffset.position, transform.rotation);
            //bullet.transform.localScale = new Vector3(Mathf.Sign(transform.localScale.x), 1, 1);

        }
        //allows reload and reload is R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.velocity = new Vector2(0, 0);
            StartCoroutine(weapon.Reload());
        }
    }
    void OnTriggerEnter2D(Collider2D other) //this is for when this object's collider collides with a trigger
                                            //things inside the bracket is a PARAMETER
    {
        if (other.GetComponent<CheckpointController>())
        {
            //sets respawn position to the collider that is held by this script
            respawnPosition = other.transform.position;


        }

    }

}
