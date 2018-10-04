using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy enemy;

    private float attackTimer = 0;
    private float attackCooldown = 2;
    private bool canAttack = true;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        if(enemy.Target != null)
        {
            enemy.Move();
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
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
            Debug.Log("Knight Attacking");
            canAttack = false;
            enemy.MyAnimator.SetTrigger("Attack");
        }
    }
}
