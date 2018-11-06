using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer sprite;

    public float speed;
    public float jump;


	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            body.AddForce(-transform.right * speed);
            sprite.flipX = true;
            animator.SetInteger("direction", 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.AddForce(transform.right * speed);
            sprite.flipX = false;
            animator.SetInteger("direction", 1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.AddForce(transform.up * jump);
            animator.SetTrigger("jump");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("roll", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("roll", false);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
        }
        else if( Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetInteger("direction", 0);
        }
        else if( Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("die", true);
        }
        else if( Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("die", false);
        }
    }
}
