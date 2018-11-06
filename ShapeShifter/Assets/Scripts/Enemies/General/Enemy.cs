using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    protected IEnemyState currentState;
	public GameObject Drop;
	public bool drops;
    public GameObject Target { get; set; }
	public Transform attackPos;
	public LayerMask Player;

    [SerializeField]
    protected float attackRange;

    // returns true if player is in attack range, false otherwise
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

    // returns if this enemy should be dead (health < 0)
    public override bool IsDead
    {
        get
        {
            return currentHealth <= 0;
        }
    }

    // Use this for initialization
    public override void Start () {
		drops = false;
		currentHealth = maxHealth;
        
        base.Start();
        ChangeState(new IdleState());
	}

	// Update is called once per frame
	void Update () {
        if (!IsDead) {
            currentState.Execute();
            LookAtTarget();
        }
	}

    // turns enemy around if player moves past enemy
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

    // makes enemy walk, if not attacking
    public void Move()
    {
        if (!Attack)
        {
            MyAnimator.SetFloat("Speed", 1);
            transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
        }

    }

    // return which direction the enemy is facing
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
		currentHealth -= damage;
		if(!IsDead){
			
			StartCoroutine(HurtBlinker(1.0f));
			Audio.PlaySound ("EnemyHurt");
			Debug.Log (currentHealth);

		} else {
			MyAnimator.SetTrigger ("Die");

			Instantiate (Drop, transform.position, transform.rotation);
			Destroy (gameObject, 1.5f);
		}
	}
    
	public void giveDamage(int dam) {
		Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Player);
		Audio.PlaySound ("EnemyAttack");
		for (int i = 0; i < enemiesToDamage.Length; i++) {
			enemiesToDamage [i].GetComponent <PlayerHealth> ().TakeDamage (dam);
		}

	}

	IEnumerator HurtBlinker(float hurtTime){
		MyAnimator.SetLayerWeight (1, 1f);
		yield return new WaitForSeconds(hurtTime);
		MyAnimator.SetLayerWeight (1, 0f);
	}
}
