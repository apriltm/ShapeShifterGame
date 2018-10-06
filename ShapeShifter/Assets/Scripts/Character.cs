﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public Animator MyAnimator { get; private set; }

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    [SerializeField]
    protected int maxHealth;
    protected int currentHealth;

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }


	// Use this for initialization
	public virtual void Start () {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeDirection() {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    /* 16.6
    public abstract IEnumerator TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(!IsDead){
            MyAnimator.SetTrigger("Damaged")
        } else {
            MyAnimator.SetTrigger("Die")
        }
    }
    */
}
