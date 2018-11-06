using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private PlayerHealth player;
	private PlayerController p;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
		//p = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
		if (player.currentHealth > 0) {
			if (col.CompareTag ("Player")) {

				player.TakeDamage (20);
				StartCoroutine (player.Knockback (0.001f));

			}
		}
	}
}
