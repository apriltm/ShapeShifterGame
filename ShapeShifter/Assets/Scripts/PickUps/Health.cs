using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	private int HealthValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			PlayerHealth player = col.gameObject.GetComponent<PlayerHealth> ();
			player.addHealth(HealthValue);
			Audio.PlaySound ("PickUp");
			Destroy (gameObject);
		}
	}
}
