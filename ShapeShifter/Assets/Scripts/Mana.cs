using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour {

	public float maxMana= 100.0f;
	public float currentMana;
	//private PlayerController player;

	//public Image currentManaBar;
	


	// Use this for initialization
	void Start () {
		currentMana = maxMana;
		//player = gameObject.GetComponent<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("Current mana is at " + currentMana);

		//Invoke ("RestoreMana", 5.0f);
	}

	public void UseMana(int cost) {
		currentMana -= cost;
	}

	void UpdateManaBar(){
		float ratio = currentMana / maxMana;

	}

	/*void RestoreMana() {


		currentMana = +5.0f;

		if (currentMana > 100) {
			currentMana = maxMana;
		}
	}*/
}
