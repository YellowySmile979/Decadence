using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5; //float is for things like speed, vectors etc.
    public float jumpSpeed = 7; //float is a decimal no.

    public Transform groundCheck;
    //transform creates an option or component under Inspector to get the Transform of a gameobject
    public float groundCheckRadius = 0.21f;
    public LayerMask whatIsGround;


    //rb is variable name that we have to declare and will be defined later
    Rigidbody2D rb;
    Animator anim;
    bool isGrounded;
    Weapon weapon;

    private bool canFire;
    private float timer;
    public float timeBetweenFiring;
    private bool canreload;

    [HideInInspector] public bool canMove = true;

    [Header("UI")]
    public Text ammoUIText;

    // Start is called before the first frame update
    void Start()
    {
        //for script to take the labelled component under Inspector
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weapon = GetComponentInChildren<Weapon>();

    }

    // Update is called once per frame
    void Update()
    {
        //if i draw a circle, is there a collider in there? thats what this is
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
        if (canMove) movement();


        ammoUIText.text = "Ammo: " + weapon.currentClip + " / " + weapon.maxClipSize + " Max Ammo: " + weapon.currentAmmo + "/" + weapon.maxAmmoSize;

    }
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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpSpeed)
            //above is what the slides say

            rb.velocity += new Vector2(0, jumpSpeed); //this is much more efficient

            //basically it forms a vector triangle which adds the x axis velocity with the y axis velocity to produce
            //the third velocity which is diagonal (basically physics)


        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }

        }

        //Possibly shooting script
        if (Input.GetButtonDown("Fire1") && canFire && !weapon.IsReloading) 
        {
            weapon.Fires();
            canFire = false;
            //Projectile bullet = Instantiate(projectilePrefab, FireOffset.position, transform.rotation);
            //bullet.transform.localScale = new Vector3(Mathf.Sign(transform.localScale.x), 1, 1);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            StartCoroutine(weapon.Reload());
        }
    }
}
