using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour {


	//movement variables
	public float maxSpeed;
	float directionx;
	Rigidbody2D myRB;

	//jumping variables
	bool grounded = true;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;


	Animator myAnim;
	bool facingRight;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();

		facingRight = true;

	}
	
	// Update is called once per frame
	public void Update() {

        if (grounded)
        {
            print("grouned");
            if (Input.GetAxis("Jump") > 0)
            {
                print("something");
                grounded = false;
                myAnim.SetBool("isGrounded", grounded);
                myRB.AddForce(new Vector2(0, jumpHeight));
            }

			directionx = CrossPlatformInputManager.GetAxis ("Horizontal");
			myRB.velocity = new Vector2 (directionx * 10, 0);

		}
	}


	 public void FixedUpdate () {

		//check if we are grounded if no, then e are falling
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
		myAnim.SetBool("isGrounded",grounded);

		myAnim.SetFloat ("verticalSpeed", myRB.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		myRB.velocity = new Vector2 (move*maxSpeed, myRB.velocity.y);

		if (move > 0 && !facingRight) {
			flip ();
		} else if (move < 0 && facingRight) { 
			flip ();
		}
	}

	void flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

}

