using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private Enemy enemy;

    private float attackTimer ;
    public float attackCooldown = 2.0f;
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
		
        
        

        if(attackTimer <=0)
        {
            
            canAttack = true;
            attackTimer = attackCooldown;
        }else
        {
            attackTimer -= Time.deltaTime;
            canAttack = false;

        }

        if (canAttack)
        {
            Debug.Log("Knight Attacking");
            canAttack = false;
            enemy.MyAnimator.SetTrigger("Attack");
            //enemy.EPoint.SetActive(true);
        }
        
    }


}
