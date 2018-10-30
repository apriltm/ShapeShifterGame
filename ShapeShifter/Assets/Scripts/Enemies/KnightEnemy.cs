using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightEnemy : Enemy {

    // Use this for initialization
    public override void Start () {
        base.Start();
        ChangeState(new IdleState());
	}

	// Update is called once per frame
	void Update () {
        if (!IsDead) {
            currentState.Execute();
            LookAtTarget();
        }
	}

    /*
     * looks to only work with melee
     */ 
	public void giveDamage(int dam) {
		Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Player);
		Audio.PlaySound ("EnemyAttack");
		for (int i = 0; i < enemiesToDamage.Length; i++) {
			enemiesToDamage [i].GetComponent <PlayerHealth> ().TakeDamage (dam);
		}

	}
}
