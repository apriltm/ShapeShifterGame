using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jumpForce;

	private Rigidbody2D rb;

	private bool facingRight = true;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJumps;
	public int extraJumpsValue;

	public Animator animator;
	public Animator animator2;

	public GameObject baseF, knight;
	int playerSelect;

	// Use this for initialization
	void Start () {
		playerSelect = 1;
		baseF = GameObject.Find ("baseF");
		knight = GameObject.Find ("knight_p");

		extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	private void Update() {
		if(isGrounded == true) {
			extraJumps = extraJumpsValue;
		}
		if (Input.GetButtonDown("Jump") && extraJumps > 0) {
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
		} else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true) {
			rb.velocity = Vector2.up * jumpForce;
		}

		if (Input.GetButtonDown ("Change")) {
			if (playerSelect == 1)
				playerSelect = 2;
			else
				playerSelect = 1;
		}

		if (playerSelect == 1) {
			baseF.SetActive (true);
			knight.SetActive (false);
			speed = 12.0f;
			jumpForce = 10.0f;
		} else {
			baseF.SetActive (false);
			knight.SetActive (true);
			speed = 5.5f;
			jumpForce = 0.0f;
		}
	}


	void FixedUpdate () {
		// left & right movement
		float xTranslation = Input.GetAxis("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs(xTranslation));
		animator2.SetFloat ("Speed", Mathf.Abs(xTranslation));
		rb.velocity = new Vector2(xTranslation * speed, rb.velocity.y);

		// flips sprite if moving the other direction
		if ((facingRight == true && xTranslation < 0) || (facingRight == false && xTranslation > 0))
			Flip();

		// checks if player is touching the ground
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler;
	}
}