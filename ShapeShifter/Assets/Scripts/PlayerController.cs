using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10.0f;
    public float jumpForce;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
	public LayerMask groundLayers;

	public Animator animator;
	public Animator animator2;

	public GameObject Main, Knight;
	int PlayerSelect;

    private int extraJumps;
    public int extraJumpsValue;

	// Use this for initialization
	void Start () {
		PlayerSelect = 1;
		Main = GameObject.Find ("Main");
		Knight = GameObject.Find ("Knight_P");
		animator.SetBool ("isJumping", false);
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    private void Update() {
		isGrounded =Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.5f, transform.position.y - 0.5f),
			new Vector2 (transform.position.x + 0.5f, transform.position.y - 0.5f), groundLayers);

        if(isGrounded == true) {
			animator.SetBool ("isJumping", false);
            extraJumps = extraJumpsValue;
        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0) {
			animator.SetBool ("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true) {
			animator.SetBool ("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
        }
		

		if (Input.GetButtonDown ("Change")) { //Grab input and then select a model for the player 
			if (PlayerSelect == 1) {
				PlayerSelect = 2;
			} else
				PlayerSelect = 1;
		}

		if (PlayerSelect == 1) { //the actually changing of the models
			speed = 12.0f; //base form will the fastest
			jumpForce = 10.0f;
			Main.SetActive (true); 
			Knight.SetActive (false);
		} else { //just using else statement for now. will change whenever we start to put in more forms
			speed = 5.5f; //knight will the slowest
			jumpForce = 0.0f; // knights will be unable to jump
			Main.SetActive (false);
			Knight.SetActive (true);
		}
    }


    void FixedUpdate () {
        // left & right movement
        float xTranslation = Input.GetAxis("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs (xTranslation)); //set the speed for the animator
		animator2.SetFloat ("Speed", Mathf.Abs (xTranslation));
        rb.velocity = new Vector2(xTranslation * speed, rb.velocity.y);

        // flips sprite if moving the other direction
        if ((facingRight == true && xTranslation < 0) || (facingRight == false && xTranslation > 0))
            Flip();
		Debug.Log (isGrounded);
        // checks if player is touching the ground
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}