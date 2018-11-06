using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy enemy;

    private float attackTimer = 1.0f;
    private float attackCooldown = 2.0f;
    private bool canAttack = true;
    
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        AttackPlayer();
        if (!enemy.InAttackRange)
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
        attackTimer += Time.deltaTime;

        if(attackTimer >= attackCooldown)
        {
            canAttack = true;
            attackTimer = 0;
        }
        if (canAttack)
        {
            canAttack = false;
            enemy.MyAnimator.SetTrigger("Attack");
        }
        
    }
}
