using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public float speed;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	void FixedUpdate() {
		TakeDamage (10);
	}

	public void TakeDamage(int dam){
		currentHealth -= dam;
		Debug.Log ("damage TAKEN");
	}
}
