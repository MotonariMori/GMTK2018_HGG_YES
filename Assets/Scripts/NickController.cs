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
    [Space(10)]
    public int iHealth;
    [Space(10)]
    public bool bOnGround;
    public bool bInhaled;
    public bool bInWater;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    private CircleCollider2D myCircleCollider;
    private SpriteRenderer mySpriteRenderer;
    [Header("Sprites")]
    public Sprite Sprite01;
    public Sprite Sprite02;
    public Sprite Sprite03;

	// Use this for initialization
	void Start () {

        //Getting the fishes Rigidbody and Box Collider
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        //Setting the fish attributes
        fSpeedInWater = 6f;
        fSpeedOnGround = 1f;
        fJumpHeight = 8f;
        bOnGround = false;
        bInhaled = false;
        bInWater = false;
        iHealth = 3;

	}
	
	// Update is called once per frame
	void Update () {

        ControlFish();
        Inhaling();

        if (myRigidbody.velocity.y == 0)
            bOnGround = true;

        if (!bOnGround && myRigidbody.velocity.x == 0)
            if (transform.rotation.x == 1)
                myRigidbody.velocity = new Vector2(-0.5f, myRigidbody.velocity.y);
            else
                myRigidbody.velocity = new Vector2(0.5f, myRigidbody.velocity.y);
    }





    //new Functions

    //Checking Collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -1f);
        mySpriteRenderer.sprite = Sprite01;
        bOnGround = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        myRigidbody.gravityScale = -0.25f;
        bInWater = true;
        bOnGround = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        myRigidbody.gravityScale = 2f;
        bInWater = false;
        mySpriteRenderer.sprite = Sprite03;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!bInWater)
        {
            bOnGround = true;
            myRigidbody.gravityScale = 2f;
            mySpriteRenderer.sprite = Sprite01;
        }
    }


    //Controls
    private void ControlFish()
    {

        if (Input.GetAxisRaw("Horizontal") < 0 && !bInhaled)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetAxisRaw("Horizontal") > 0 && !bInhaled)
            transform.localScale = new Vector3(1, 1, 1);

        //Controlling the fish in water
        if (bInWater && !bInhaled)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
                if (myRigidbody.velocity.x < 5f)
                    myRigidbody.AddForce(new Vector2(fSpeedInWater * Input.GetAxisRaw("Horizontal"), 0f));


            if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
                if (myRigidbody.velocity.y < 3f || myRigidbody.velocity.y > -3f)
                    myRigidbody.AddForce(new Vector2(0f, fSpeedInWater * Input.GetAxisRaw("Vertical")));

        }

        //Controlling the fish on ground
        //Checks, if the fish is on the ground
        else if (bOnGround && !bInhaled)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
            {

                myRigidbody.velocity = new Vector2(fSpeedOnGround * Input.GetAxisRaw("Horizontal"), fJumpHeight * Mathf.Abs(Input.GetAxisRaw("Horizontal")));
                bOnGround = false;
                mySpriteRenderer.sprite = Sprite03;
                StartCoroutine("SpriteChange");
            }
        }


        //Controlling Inhaled fish on ground
        
        //Checks, if the fish is on the ground
        else if (bOnGround && bInhaled)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
            {
                myRigidbody.AddForce(new Vector2(fSpeedOnGround * 2 * Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y));
                transform.Rotate(Vector3.forward);

            }
        }
        /*else
        {
            //myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y);
        }*/

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
            myCircleCollider.enabled = false;
            myBoxCollider.enabled = true;
            bInhaled = false;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            myRigidbody.freezeRotation = true;
        }
    }

    private IEnumerator SpriteChange()
    {
        yield return new WaitForSeconds(.5f);
        if (!bInhaled)
            mySpriteRenderer.sprite = Sprite01;
        
    }
}
