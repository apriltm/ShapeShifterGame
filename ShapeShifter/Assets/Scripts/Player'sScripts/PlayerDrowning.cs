using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrowning : MonoBehaviour {

	public float drownTime;
	private float drownTimer;
	private PlayerHealth player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D collision){
		if (collision.tag == "Water") {
			drownTimer += Time.deltaTime;
			Debug.Log ("underwater");
		} else {
			drownTimer = 0;
		}

		if (drownTimer > drownTime) {
			player.currentHealth = 0;
		}
	}
}
