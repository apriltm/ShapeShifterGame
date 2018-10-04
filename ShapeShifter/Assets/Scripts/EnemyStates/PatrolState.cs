using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private Enemy enemy;

    private float patrolTimer;
    private float patrolDuration = 20;
    private float directionDuration = 2; // Time until enemy turns around

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        Debug.Log("Knight Patrolling");
    }

    public void Execute()
    {
        Patrol();
        enemy.Move();

        if(enemy.Target != null)
        {
            enemy.ChangeState(new AttackState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        Debug.Log("Patrol Colliding");
        enemy.ChangeDirection();
        
    }

    void Patrol()
    {
        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
