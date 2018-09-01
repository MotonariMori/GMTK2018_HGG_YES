using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickController : MonoBehaviour {

    public float fSpeedInWater;
    [SerializeField]
    private float fSpeedOnGround;
    public float fJumpHeight;
    public bool bOnGround;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();

        fSpeedInWater = 6f;
        fSpeedOnGround = fSpeedInWater * 0.15f;
        fJumpHeight = 6f;
        bOnGround = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (myBoxCollider.isTrigger)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
                myRigidbody.velocity = new Vector2(fSpeedInWater * Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y);
            else
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);

            if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, fSpeedInWater * Input.GetAxisRaw("Vertical"));
            else
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }
        else
        {
            if (bOnGround)
            {
                if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
                {
                    myRigidbody.velocity = new Vector2(fSpeedOnGround * Input.GetAxisRaw("Horizontal"), fJumpHeight * Mathf.Abs(Input.GetAxisRaw("Horizontal")));
                    bOnGround = false;
                }
            }


        }


	}

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
}
