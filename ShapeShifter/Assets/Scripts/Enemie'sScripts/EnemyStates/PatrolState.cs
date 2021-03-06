﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private Enemy enemy;

    private float patrolTimer = 0;
    private float patrolDuration = 1000;

    private float collideTimer = 0;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Patrol();
        enemy.Move();
        if (enemy.Target != null && enemy.InAttackRange)
        {
            Debug.Log("Patrol state -> attack state");
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
            if (other.tag == "Edge"||other.tag== "Enemy")
            {
                enemy.ChangeDirection();
                collideTimer = 0;
            }
        }
        
    }

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
