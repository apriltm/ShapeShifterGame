using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KE_Health : Enemy {

	public int maxHealth;
	public int currentHealth;
	public float speed;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		MyAnimator.SetFloat ("HP", currentHealth);
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			MyAnimator.SetFloat ("HP", currentHealth);
			Destroy (gameObject, 2.5f);
		}
	}

	void FixedUpdate() {

	}

	public void TakeDamage(int dam){
		currentHealth -= dam;
		Debug.Log ("damage TAKEN");
	}
}
