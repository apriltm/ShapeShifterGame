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
			Destroy (gameObject, 3.0f);

		}

	}

	void FixedUpdate() {
		
	}

	public void TakeDamage(int dam){

			//player.animator.SetTrigger ("Damaged");
			//gameObject.GetComponent<Animation> ().Play ("Hurt");
			currentHealth -= dam;
			Debug.Log (currentHealth);
			
	}
	 

}
