using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{

    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        Debug.Log("Knight Attacking");
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
        throw new System.NotImplementedException();
    }
}
