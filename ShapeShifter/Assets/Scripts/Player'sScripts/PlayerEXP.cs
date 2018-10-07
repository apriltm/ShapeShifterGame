using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEXP : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		
		player = gameObject.GetComponent<PlayerController> ();
		player.Player_current_exp = 19;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void addExp() {
		player.Player_current_exp += 1;
		if (player.Player_current_exp == 20) {
			player.Player_current_lvl = +1;
			player.Player_current_exp = 0;
		}
		Debug.Log (player.Player_current_exp);
	}
}
