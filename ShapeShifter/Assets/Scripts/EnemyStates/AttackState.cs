using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy enemy;

    private float attackTimer = 0;
    private float attackCooldown = 2f;
    private bool canAttack = true;



    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        AttackPlayer();
        if (!enemy.InMeleeRange)
        {
            enemy.ChangeState(new PatrolState());
        }
        else if(enemy.Target == null)
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
		/*
        enemy.MyAnimator.SetTrigger("Attack");
        */
        
        attackTimer += Time.deltaTime;

        if(attackTimer >= attackCooldown)
        {
            canAttack = true;
            attackTimer = 0;
        }
        if (canAttack)
        {
            Debug.Log("Knight Attacking");
            canAttack = false;
            enemy.MyAnimator.SetTrigger("Attack");

        }
        
    }
}
