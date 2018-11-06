using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {



	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Attack")) {

			Debug.Log ("FUCK");
		}
}


	//void OnTriggerEnter2D4

	/*void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRange);
	}*/
}
