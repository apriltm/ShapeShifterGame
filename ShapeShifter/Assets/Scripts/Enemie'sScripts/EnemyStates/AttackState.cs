using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy enemy;

    private float attackTimer;
    public float attackCooldown = 2.0f;
    private bool canAttack = true;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        Debug.Log("Entering attack state");
    }

    public void Execute()
    {
        Timer();

        AttackPlayer();
        if (!enemy.InAttackRange)
        {
            Debug.Log("Attack state -> Patrol state");
            enemy.ChangeState(new PatrolState());
        }
        else if(enemy.Target == null)
        {
            Debug.Log("Attack state -> Idle state");
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Edge" || other.tag == "Enemy")
        {
            enemy.ChangeDirection();
        }
    }

    public void Timer()
    {
        if (attackTimer <= 0)
        {
            canAttack = true;
            attackTimer = attackCooldown;
        }
        else
        {
            attackTimer -= Time.deltaTime;
            canAttack = false;
        }
    }

    private void AttackPlayer()
    {
        if (canAttack)
        {
            canAttack = false;
            enemy.MyAnimator.SetTrigger("Attack");
        }
    }
    
}
