using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player_movement : MonoBehaviour {

    // Variable to contain move firection in x axis
    float dirX;

    // Varable for move speed and jump force adjustable to inspector
    public float moveSpeed = 5f, jumpForce = 700f;

    // Reference to Rigidbody2D component
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        // Getting Rigibody2D component to operate it
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        // Getting dirX value when any of UI move buttons is pressed
        dirX = CrossPlatformInputManager.GetAxis ("Horizontal");

        // If jump button is pressed then DoJump method is invoked
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
            DoJump();
	}

    private void FixedUpdate()
    {
        // Pass 0 velocity to Rigidbody2D component according to dirX value multiplied by move speed
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    // Public jump method which is invoked when jump UI button is pressed
    public void DoJump()
    {
        // simple check to not allow the player to jump while in the air
        if (rb.velocity.y == 0)
        {

            // add force to rigidbody2D component in y direction
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
    }
}
