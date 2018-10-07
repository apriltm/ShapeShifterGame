using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	public int maxHealth;
    private IEnemyState currentState;
	public GameObject Drop;
	public bool drops;
    public GameObject Target { get; set; }

	// Use this for initialization
	public override void Start () {
		drops = false;
		//MyAnimator.SetBool ("Dead", false);
		currentHealth = maxHealth;
        Debug.Log("Enemy start");
        base.Start();
        ChangeState(new IdleState());
       
        currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			drops = true;
			if (drops) {
				Instantiate (Drop, transform.position, transform.rotation);
			}
			Destroy (gameObject);
		}

        currentState.Execute();
        LookAtTarget();
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
        MyAnimator.SetFloat("Speed", 1);
        transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(other);
    }

	public void TakeDamage(int damage){
		currentHealth -= damage;
		Debug.Log (currentHealth);
	}
}
