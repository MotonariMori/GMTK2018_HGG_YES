using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController2D : MonoBehaviour
{
    [SerializeField] private float jumpForce = 200f;                  //Amount of force added when jumping
    [SerializeField] private LayerMask whatIsGround;                  //A mask determining what ground player is standing on
    private Rigidbody2D Player;
    private bool facingRight = true;                                  //Determins which way the player's facing

    void Start () {
        Player = GetComponent<Rigidbody2D>();
	}
	
    public void Move (float move)
    {
        Player.AddForce(new Vector2(move, 0));
    }

	void Update () {
		
	}
}
