using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightEnemy : Enemy {

    // Use this for initialization
    public override void Start () {
        base.Start();
	}

	// Update is called once per frame
	void Update () {
        if (!IsDead) {
            currentState.Execute();
            LookAtTarget();
        }
	}
    
	public void giveDamage(int dam) {
		Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Player);
		Audio.PlaySound ("EnemyAttack");
		for (int i = 0; i < enemiesToDamage.Length; i++) {
			enemiesToDamage [i].GetComponent <PlayerHealth> ().TakeDamage (dam);
		}
        /*
        foreach(Collider2D enemy in enemiesToDamage) {
			enemy.GetComponent <PlayerHealth> ().TakeDamage (dam);
		}
        */
	}
}
