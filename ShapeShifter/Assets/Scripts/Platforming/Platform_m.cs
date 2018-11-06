using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_m : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float fallDelay;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.CompareTag ("Player")) {
			StartCoroutine (Fall ());
		}
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds (fallDelay);
		rb2d.isKinematic = false;
		yield return 0;
	}
}
