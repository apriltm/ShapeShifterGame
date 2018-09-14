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

    private int extraJumps;
    public int extraJumpsValue;

	// Use this for initialization
	void Start () {
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
    }


    void FixedUpdate () {
        // left & right movement
        float xTranslation = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xTranslation * speed, rb.velocity.y);

        // flipping sprite
        if ((facingRight == true && xTranslation < 0) || (facingRight == false && xTranslation > 0))
            Flip();

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
