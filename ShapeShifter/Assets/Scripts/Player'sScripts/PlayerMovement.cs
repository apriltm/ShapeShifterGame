using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public AnimatorController animator;
    public float speed;
    public float jumpForce;
    public bool extraJump;
    private bool facingRight = true;
    public bool canMove;
    public Rigidbody2D rb;
    private SelectForm Forms;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool wallCheck;
    public bool isGrounded;

    

    // Use this for initialization
    void Start () {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        Forms = gameObject.GetComponent<SelectForm>();
        animator = gameObject.GetComponent<AnimatorController>();
        
    }
	
	// Update is called once per frame
	void Update () {
        Check();
        setSpeed_Jump();
        MoveHor();
        Jump();
	}

    void Check()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x -.2f , transform.position.y - .75f),
            new Vector2(transform.position.x + .2f, transform.position.y - .75f), groundLayer);
        wallCheck = Physics2D.OverlapArea(new Vector2(transform.position.x - 1.5f, transform.position.y),
            new Vector2(transform.position.x + 1.5f, transform.position.y), groundLayer);

    }

    void MoveHor()
    {
        // left & right movement

        float xTranslation = Input.GetAxis("Horizontal");
        animator.MainAnimator.SetFloat("Speed", Mathf.Abs(xTranslation)); //set the speed for the animator
        animator.KnightAnimator.SetFloat("Speed", Mathf.Abs(xTranslation));
        animator.MageAnimator.SetFloat("Speed", Mathf.Abs(xTranslation));
        rb.velocity = new Vector2(xTranslation * speed, rb.velocity.y);

        if (!canMove)
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
        // flips sprite if moving the other direction
        if ((facingRight == true && xTranslation < 0) || (facingRight == false && xTranslation > 0))
            Flip();


    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void setSpeed_Jump()
    {
        if(Forms.PlayerSelect ==1)
        {
            speed = 7.0f; //base form will the fastest
            jumpForce = 13.5f;
        }
        else if (Forms.PlayerSelect == 2)
        {
            speed = 3.5f; //knight will the slowest
            jumpForce = 9.0f; // knights will be unable to jump
        }
        else if (Forms.PlayerSelect == 3)
        {
            speed = 5.0f; //knight will the slowest
            jumpForce = 11.0f; // knights will be unable to jump
        }
    }

    void Jump()
    {


        if (isGrounded == true||wallCheck)
        {
            animator.MainAnimator.SetBool("isJumping", false);
            animator.MainAnimator.SetBool("isFalling", false);
            extraJump = true;
           
        }
        if (isGrounded == false)
        {
            HandleJumpAndFall();
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            Audio.PlaySound("Jumping");
            
            HandleJumpAndFall();
            
            rb.velocity = Vector2.up * jumpForce;
            if (Forms.PlayerSelect != 1)
                extraJump = false;
            
        }
        else if (Input.GetButtonDown("Jump")  
            && extraJump)
        {
            
            HandleJumpAndFall();
            Audio.PlaySound("Jumping");
            rb.velocity = Vector2.up * jumpForce;
            extraJump = false;
        }


    }

    void HandleJumpAndFall()
    {
        if (isGrounded == false)
        {
            if (rb.velocity.y > 0)
            {
                animator.MainAnimator.SetBool("isJumping", true);
            }
            else if (rb.velocity.y < 0)
            {
                animator.MainAnimator.SetBool("isJumping", false);
                animator.MainAnimator.SetBool("isFalling", true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }

        Debug.Log("HITTING SOMETHING");
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - .75f),
            new Vector2(1, 0.01f));
    }
}
