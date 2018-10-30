using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttackState : AttackState
{
    private Enemy enemy;

    private float attackTimer = 1.0f;
    private float attackCooldown = 2.0f;
    private bool canAttack = true;

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
            Debug.Log("Mage Attacking");
            canAttack = false;
            enemy.MyAnimator.SetTrigger("Attack");

        }
        
    }
}
