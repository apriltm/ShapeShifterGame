using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

	public float fireRate = 0f;
	public float damage = 10f;
	public GameObject SpellCast;
	public Transform Point;
	public LayerMask NotHit;

	private float timeBtwShots;

	float timeToFire = 0;
	Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.Log ("ERROR");
		} else {
			Debug.Log ("FOUND");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Attack")) {
				Instantiate (SpellCast, Point.position, transform.rotation);
				Shoot ();
			}
		} else {
			if (Input.GetButtonDown ("Attack") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			}
		}
	}

	void Shoot (){
		Vector2 mousePostion = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x
			, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePostion-firePointPosition, 100f, NotHit);
		Debug.DrawLine (firePointPosition, mousePostion);
		if (hit.collider != null) {
			Debug.Log(hit.collider.name);
		}
	}
}
