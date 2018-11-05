using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour {

	// Use this for initialization
	void FixedUpdate () {

		Destroy (gameObject, .5f);
	}

}
