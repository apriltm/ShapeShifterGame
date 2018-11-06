using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttackState : AttackState
{
    private Enemy enemy;

    private float attackTimer = 1.0f;
    private float attackCooldown = 2.0f;
    private bool canAttack = true;
    
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
