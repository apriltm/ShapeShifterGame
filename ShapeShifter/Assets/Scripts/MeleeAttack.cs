using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public Animator animator;
    private PlayerMovement player;
    

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponentInParent<PlayerMovement>();
        
    }
	
	// Update is called once per frame
	void Update () {
        AttackAnimation();
	}

    void AttackAnimation()
    {
        if (Input.GetMouseButtonDown(0) && player.isGrounded && timeBtwAttack <= 0)
        {
            Audio.PlaySound("PlayerAttack");
            animator.SetBool("isAttacking", true);
            timeBtwAttack = startTimeBtwAttack;
            player.canMove = false;
            Invoke("resetAttack", .25f);
        } else
        {
            timeBtwAttack -= Time.deltaTime;
            animator.SetBool("isAttacking", false);
        }
    }

    void resetAttack()
    {
        player.canMove = true;
    }

    void DealDamage(int damage)
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
