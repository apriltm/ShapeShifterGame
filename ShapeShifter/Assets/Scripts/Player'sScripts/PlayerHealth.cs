using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	private PlayerController player;

	
	// Use this for initialization
	void Start () {
		
		currentHealth = maxHealth;
		player = gameObject.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			player.animator.SetTrigger ("Dies");
			 
			player.enabled = false;
			Destroy (gameObject, 3.0f);

		}

	}

	void FixedUpdate() {
		
	}

	public void TakeDamage(int dam){

		currentHealth -= dam;
		Debug.Log (currentHealth);

		if (currentHealth > 0) {
			player.animator.SetTrigger ("Damaged");
			Audio.PlaySound ("PlayerHurt");
			//gameObject.GetComponent<Animation> ().Play ("Hurt");


		}		
	}
	 

}
