using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    protected IEnemyState currentState;
    public GameObject Drop;
    public bool drops;
    public GameObject Target { get; set; }
    public Transform attackPos;
    public float attackRange;
    public LayerMask Player;
    public int LeftRight;
    public Transform[] moveSpots;
    public int currentSpot = 0;

    //public GameObject EPoint;

    // meleeRange not being used
    //[SerializeField]
    private float meleeRange;
    protected ShakeControl Cam;

    Rigidbody2D rb;

    public bool InAttackRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= attackRange;
            }
            return false;
        }
    }

    public override bool IsDead
    {
        get
        {
            return currentHealth <= 0;
        }
    }

    // Use this for initialization
    public override void Start () {
        base.Start();
        Cam = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeControl>();
        drops = false;
		currentHealth = maxHealth;
        ChangeState(new IdleState());
        rb = GetComponent<Rigidbody2D>();
	}

    void StartingDir()
    {
        if (LeftRight == 0)
            facingRight = true;
        else
            facingRight = false;
    }

	// Update is called once per frame
	void Update ()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (!IsDead) {
            currentState.Execute();
            LookAtTarget();
        }
	}

    protected void LookAtTarget()
    {
        if(Target != null) {
            float xDirection = Target.transform.position.x - transform.position.x;

            if ((xDirection < 0 && facingRight) || (xDirection > 0 && !facingRight)) {
                ChangeDirection();
            }
        }
    }

    public void ChangeState(IEnemyState newState) {
        if(currentState != null) {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }
    
    public void Move()
    {
        if (!Attack)
        {
            MyAnimator.SetFloat("Speed", 1);
            transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
        }
    }

    public void setSpeed(float speed)
    {
        movementSpeed = speed;
    }


    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(other);
    }


	public override void TakeDamage(int damage)
	{
        Cam.ShakeCamera(.3f);
		currentHealth -= damage;
		if(!IsDead){
			
			StartCoroutine(HurtBlinker(1.0f));
			Audio.PlaySound ("EnemyHurt");
			Debug.Log (currentHealth);

		} else {
            Audio.PlaySound("EnemyHurt");
            MyAnimator.SetTrigger ("Die");

			Instantiate (Drop, transform.position, transform.rotation);
			Destroy (gameObject, 1.5f);
		}
	}

	public void giveDamage(int dam) {
		
		Audio.PlaySound ("EnemyAttack");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Player);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<PlayerHealth>().TakeDamage(dam);
        }

    }
	IEnumerator HurtBlinker(float hurtTime){
		MyAnimator.SetLayerWeight (1, 1f);
		yield return new WaitForSeconds(hurtTime);
		MyAnimator.SetLayerWeight (1, 0f);
	}
}
