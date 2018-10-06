using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPickup : MonoBehaviour {

	public float exp;
	public float knight_Exp;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			PlayerEXP player = col.gameObject.GetComponent<PlayerEXP> ();
			player.addExp (1);
			Destroy (gameObject);
		}
	}
}
