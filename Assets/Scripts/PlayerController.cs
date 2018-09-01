using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharController2D controller; 
    private float horizontalMovement;
    public float movementSpeed;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharController2D>();
	}
	
	// Update is called once per frame
	void Update () {
        horizontalMovement = (Input.GetAxisRaw("Horizontal") * movementSpeed);
        controller.Move(horizontalMovement);
    }
}
