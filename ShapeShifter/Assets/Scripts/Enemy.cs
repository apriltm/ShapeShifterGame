using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    private IEnemyState currentState;
    public GameObject Target { get; set; }

	// Use this for initialization
	public override void Start () {
        Debug.Log("Enemy start");
        base.Start();
        ChangeState(new IdleState());
        maxHealth = 100;
        currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update () {
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
        Debug.Log("Enemy Colliding");
        currentState.OnTriggerEnter(other);
    }
}
