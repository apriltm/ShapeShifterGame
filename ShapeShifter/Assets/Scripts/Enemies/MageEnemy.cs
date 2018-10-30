using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * TODO: 
 *  larger attack range
 *  
 *  check player in range
 *      check if canFire
 * 
 */
public class MageEnemy : Enemy {

    [SerializeField]
    GameObject fireball;

    float fireRate;
    float timeSinceFire;

    // fireball cooldown
    bool canFire
    {
        get
        {
            return timeSinceFire < fireRate;
        }
    }
    
    // Use this for initialization
    public override void Start () {
        //MyAnimator.SetBool ("Dead", false);
        
		drops = false;
		currentHealth = maxHealth;

        Debug.Log("Enemy start");
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


	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if(!IsDead){
			
			StartCoroutine(HurtBlinker(1.0f));
			Audio.PlaySound ("EnemyHurt");
			Debug.Log (currentHealth);

		} else {
			MyAnimator.SetTrigger ("Die");

			Instantiate (Drop, transform.position, transform.rotation);
			Destroy (gameObject, 1.5f);

		}
	}

	public void giveDamage(int damage) {
		Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Player);
		Audio.PlaySound ("EnemyAttack");
		for (int i = 0; i < enemiesToDamage.Length; i++) {
			enemiesToDamage [i].GetComponent <PlayerHealth> ().TakeDamage (damage);

		}

	}
	IEnumerator HurtBlinker(float hurtTime) {

		//int enemyLayer = LayerMask.NameToLayer ("Enemy");
		//int playerLayer = LayerMask.NameToLayer ("Player");
		//Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer);

		MyAnimator.SetLayerWeight (1, 1f);

		yield return new WaitForSeconds(hurtTime);

		//Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer, false);

		MyAnimator.SetLayerWeight (1, 0f);
	}
}
