using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPickup : MonoBehaviour {

	
    private PlayerXP player;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
            player = col.gameObject.GetComponent<PlayerXP>();
            player.AddExp();
			Audio.PlaySound ("PickUp");
			Destroy (gameObject);
		}
	}
}
