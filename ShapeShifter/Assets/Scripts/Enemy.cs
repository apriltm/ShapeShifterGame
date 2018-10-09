using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    private IEnemyState currentState;
	public GameObject Drop;
	public bool drops;
    public GameObject Target { get; set; }
	public Transform attackPos;
	public float attackRange;
	public LayerMask Player;

    [SerializeField]
    private float meleeRange;

    public bool InMeleeRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
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
        //MyAnimator.SetBool ("Dead", false);
        
		drops = false;
		currentHealth = maxHealth;

        Debug.Log("Enemy start");
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

    private void LookAtTarget()
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

	/*public void TakeDamage(int dam){

		currentHealth -= dam;
		Debug.Log (currentHealth);
	}*/

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(other);
    }

	/*public override void OnTriggerEnter2D(Collider2D col) {
		base.OnTriggerEnter2D (col);
		currentState.OnTriggerEnter (col);
	}*/

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if(!IsDead){
			MyAnimator.SetTrigger ("Damaged");
			Debug.Log (currentHealth);

		} else {
			MyAnimator.SetTrigger ("Die");
			Instantiate (Drop, transform.position, transform.rotation);
			Destroy (gameObject, 1.5f);

		}
	}

	public void giveDamage(int dam) {
		Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Player);

		for (int i = 0; i < enemiesToDamage.Length; i++) {
			enemiesToDamage [i].GetComponent <PlayerHealth> ().TakeDamage (dam);
		}

	}
}
