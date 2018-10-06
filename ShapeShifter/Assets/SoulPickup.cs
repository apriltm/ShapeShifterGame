using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPickup : MonoBehaviour {

	public float exp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			//PlayerController player = col.gameObject.GetComponent<PlayerController> ();
			//player.addEXP (exp);
			Destroy(gameObject);
		}
	}
}
