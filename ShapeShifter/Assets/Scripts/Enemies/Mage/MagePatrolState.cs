using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagePatrolState : PatrolState
{
    private Enemy enemy;

    private float patrolTimer = 0;
    private float patrolDuration = 10;

    private float collideTimer = 0;
    /*
    public void Execute()
    {
        Patrol();
        enemy.Move();

        if(enemy.Target != null && enemy.InAttackRange)
        {
            enemy.ChangeState(new AttackState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (collideTimer > 1)
        {
            if (other.tag == "Edge")
            {
                enemy.ChangeDirection();
                collideTimer = 0;
            }
        }
        
    }
    */
    void Patrol()
    {
        patrolTimer += Time.deltaTime;
        collideTimer += Time.deltaTime;
        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
