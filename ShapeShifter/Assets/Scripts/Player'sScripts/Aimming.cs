﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimming : MonoBehaviour {


	public float RotateOffset;
	public GameObject projectile;
	public Transform shotPoint;

	private float timeBtwShots;
	public float startTimeBtwShots;

	private PlayerController player;

	void Start() {
		player = gameObject.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position; // subtracting the position of the player from the mouse position.
		//difference.Normalize (); // normalizing the vector. Meaning that all the sum of the vector will be equal to 1.

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; //convert angle to degrees
		transform.rotation =Quaternion.Euler (0f, 0f, rotZ + RotateOffset);

		if (timeBtwShots <= 0) {
			if (Input.GetMouseButtonDown (0)) {
				//player.animator3.SetTrigger ("BasicAtt");
				Instantiate (projectile, shotPoint.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
		} else {
			timeBtwShots -= Time.deltaTime;
		}
	}
}
