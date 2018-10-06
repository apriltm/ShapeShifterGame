using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10.0f;
    public float jumpForce;

    private Rigidbody2D rb;

	public GameObject SE;
    private bool facingRight = true;

	private float timeBtwAttack;
	public float startTimeBtwAttack;

	public Transform attackPos;
	public LayerMask whatIsEnemies;
	public float attackRange;
	public int damage;

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

	private bool attack;

	// Use this for initialization
	void Start () {
		attack = false;
		PlayerSelect = 1;
		Main = GameObject.Find ("Main");
		Knight = GameObject.Find ("Knight_P");
		//animator.SetBool ("isJumping", false);
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
	}


    // Update is called once per frame
    private void Update() {
		/*isGrounded =Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.5f, transform.position.y - 0.5f),
			new Vector2 (transform.position.x + 0.5f, transform.position.y - 0.5f), groundLayers);*/

		isGrounded =Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.5f, transform.position.y - 0.5f),
			new Vector2 (transform.position.x + 0.5f, transform.position.y - 0.5f), groundLayers);


		//Debug.Log (isGrounded);
		Jump ();
		selectF ();
		Shift ();
		CharAttack ();

    }


    void FixedUpdate () {
		if (attack == false) {	
			MoveHor ();
		}
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRange);
	}

	void MoveHor()
	{
		// left & right movement
		float xTranslation = Input.GetAxis("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs (xTranslation)); //set the speed for the animator
		animator2.SetFloat ("Speed", Mathf.Abs (xTranslation));
		rb.velocity = new Vector2(xTranslation * speed, rb.velocity.y);

		// flips sprite if moving the other direction
		if ((facingRight == true && xTranslation < 0) || (facingRight == false && xTranslation > 0))
			Flip();

	
	}

	void CharAttack() {
		/*if (Input.GetButtonDown ("Attack")) {
			attack = true;
			animator.SetBool ("isAttacking", true);
			animator2.SetBool ("isAttacking", true);
			Debug.Log ("attack");
			Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll (attackPos.position, attackRange, whatIsEnemies);
			if (PlayerSelect == 1) {
				damage = 45;
			} else if (PlayerSelect == 2) {
				damage = 75;
			}
			for (int i = 0; i < enemiesToDamage.Length; i++) {
				enemiesToDamage [i].GetComponent<KE_Health> ().TakeDamage (damage);
			}

		} else {
			animator.SetBool ("isAttacking", false);
			animator2.SetBool ("isAttacking", false);
			attack = false;
		}*/

		if (timeBtwAttack <= 0) {
			if(Input.GetButtonDown("Attack" )){
				animator.SetBool ("isAttacking", true);
				animator2.SetBool ("isAttacking", true);
				timeBtwAttack = startTimeBtwAttack;
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
				DamageFactor ();
				for (int i = 0; i < enemiesToDamage.Length; i++) {
					enemiesToDamage [i].GetComponent < Enemy> ().TakeDamage (damage);
				}

			}
			timeBtwAttack = startTimeBtwAttack;
		} else {
			timeBtwAttack -= Time.deltaTime;
			animator.SetBool ("isAttacking", false);
			animator2.SetBool ("isAttacking", false);
		}

	}

	void selectF(){
		if (Input.GetButtonDown ("Change")) { //Grab input and then select a model for the player 
			Instantiate(SE,transform.position, transform.rotation = Quaternion.identity);
			if (PlayerSelect == 1) {
				PlayerSelect = 2;
			} else
				PlayerSelect = 1;
		} 
	}


	void Shift(){
		if (PlayerSelect == 1) { //the actually changing of the models
			speed = 7.0f; //base form will the fastest
			jumpForce = 9.0f;
			Main.SetActive (true); 
			Knight.SetActive (false);
	} 	else { //just using else statement for now. will change whenever we start to put in more forms
			speed = 3.5f; //knight will the slowest
			jumpForce = 0.0f; // knights will be unable to jump
			Main.SetActive (false);
			Knight.SetActive (true);
	}
}

	void Jump(){
		if(isGrounded == true) {
			animator.SetBool ("isJumping", false);
			extraJumps = extraJumpsValue;
		}
		if (isGrounded == false) {
			animator.SetBool ("isJumping", true);
		}
		if (Input.GetButtonDown("Jump") && extraJumps > 0) {
			animator.SetBool ("isJumping", false);
			animator.SetBool ("isJumping", true);
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
		} else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true) {
			animator.SetBool ("isJumping", false);
			animator.SetBool ("isJumping", true);
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void DamageFactor()
	{
		if (PlayerSelect == 1) {
			damage = 45;
		} else if (PlayerSelect == 2) {
			damage = 75;
		}
	}
	/*void OnDrawGizmosSelected(){

	}*/

}