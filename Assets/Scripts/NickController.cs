using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickController : MonoBehaviour {

    //Variables
    [Header("Fish Attributes")]
    public float fSpeedInWater;
    [SerializeField]
    private float fSpeedOnGround;
    public float fJumpHeight;
    public bool bOnGround;
    public bool bInhaled;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    private CircleCollider2D myCircleCollider;
    private SpriteRenderer mySpriteRenderer;
    [Header("Sprites")]
    public Sprite Sprite01;
    public Sprite Sprite02;

	// Use this for initialization
	void Start () {

        //Getting the fishes Rigidbody and Box Collider
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        //Setting the fish attributes
        fSpeedInWater = 6f;
        fSpeedOnGround = fSpeedInWater * 0.15f;
        fJumpHeight = 6f;
        bOnGround = false;
        bInhaled = false;

	}
	
	// Update is called once per frame
	void Update () {

        ControlFish();
        Inhaling();

	}





    //new Functions

    //Checking Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            myBoxCollider.isTrigger = true;
            myRigidbody.gravityScale = -0.5f;
        }
        else
            bOnGround = true;
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myBoxCollider.isTrigger = false;
        myRigidbody.gravityScale = 2f;
    }


    //Controls
    private void ControlFish()
    {
        //Controlling the fish in water
        if (myBoxCollider.isTrigger)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)                                    //Horizontal Input
                myRigidbody.velocity = new Vector2(fSpeedInWater * Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y);
            else
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);                                                     //Stopping velocity

            if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)                                        //Vertical Input
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, fSpeedInWater * Input.GetAxisRaw("Vertical"));
            else
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);                                                     //Stopping velocity
        }

        //Controlling the fish on ground
        else
        {
            //Checks, if the fish is on the ground
            if (bOnGround && !bInhaled)
            {
                if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
                {
                    myRigidbody.velocity = new Vector2(fSpeedOnGround * Input.GetAxisRaw("Horizontal"), fJumpHeight * Mathf.Abs(Input.GetAxisRaw("Horizontal")));
                    bOnGround = false;
                }
            }


        }

        //Controlling Inhaled fish on ground
        
        //Checks, if the fish is on the ground
        if (bOnGround && bInhaled)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
            {
                myRigidbody.AddForce(new Vector2(fSpeedOnGround * 2 * Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y));
                transform.rotation = new Quaternion(0f, 0f, 0f, myRigidbody.velocity.x);

            }
        }

    }



    //Controlling the Inhaling of the fish
    private void Inhaling()
    {
        if (Input.GetAxisRaw("Inhale") > 0.5f || Input.GetAxisRaw("Inhale") < -0.5f)
        {
            mySpriteRenderer.sprite = Sprite02;
            myCircleCollider.enabled = true;
            myBoxCollider.enabled = false;
            bInhaled = true;
            myRigidbody.freezeRotation = false;
        }
        else
        {
            mySpriteRenderer.sprite = Sprite01;
            myCircleCollider.enabled = false;
            myBoxCollider.enabled = true;
            bInhaled = false;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            myRigidbody.freezeRotation = true;
        }
    }
}
