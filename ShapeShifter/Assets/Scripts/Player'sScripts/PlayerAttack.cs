using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {




	// Update is called once per frame
	void Update () {


}


	//void OnTriggerEnter2D4

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRange);
	}
}
