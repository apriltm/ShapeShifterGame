﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public Animator animator;
    private PlayerMovement player;
    float temp;
    private float startFreeze;
    private float FreezeTimer;

    private float timeBtwAttack =.5f;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public LayerMask WhatIsWall;
    public float attackRange;
    private ShakeControl Cam;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponentInParent<PlayerMovement>();
        Cam = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeControl>();
    }
	
	// Update is called once per frame
	void Update () {
        AttackAnimation();
	}

    void AttackAnimation()
    {
        if (Input.GetMouseButtonDown(0) && timeBtwAttack <= 0 )
        {
            if (!player.isGrounded)
            {
                animator.SetTrigger("AirAttack");
                Cam.ShakeCamera(.3f);
                //animator.SetBool("isAttacking", true);
                timeBtwAttack = startTimeBtwAttack;
                player.canMove = false;
                Invoke("resetAttack", .25f);
            }
            if (player.isGrounded)
            {
                Cam.ShakeCamera(.3f);
                animator.SetBool("isAttacking", true);
                timeBtwAttack = startTimeBtwAttack;
                player.canMove = false;
                Invoke("resetAttack", .25f);
            }
        } else
        {

            //FreezeTimer -= Time.deltaTime;
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
        Audio.PlaySound("PlayerAttack");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
           
        }
        Collider2D[] breakwall = Physics2D.OverlapCircleAll(attackPos.position, attackRange, WhatIsWall);
        for (int i = 0; i < breakwall.Length; i++)
        {
            breakwall[i].GetComponent<DestroyableWall>().Brake();

        }
    }
}
