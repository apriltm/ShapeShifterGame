using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private PlayerHealth player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			player.TakeDamage (25);
			Debug.Log ("hurt");
		}

	}
}
