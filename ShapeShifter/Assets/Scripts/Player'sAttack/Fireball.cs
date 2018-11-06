﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public float distance;
	public int damage;
    public GameObject SFX;

	public LayerMask whatIsSolid;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hitinfo = Physics2D.Raycast (transform.position, transform.up, distance, whatIsSolid);
		if (hitinfo.collider != null) {
			if (hitinfo.collider.CompareTag ("Enemy")) {
                //Debug.Log ("ENEMY HIT!");
                if (gameObject.tag == "arrow")
                    Audio.PlaySound("BowHit");
                hitinfo.collider.GetComponent<Enemy> ().TakeDamage (damage);
			}
			DestoryProjectile (0);
		}

		transform.Translate (Vector2.up * speed * Time.deltaTime);
		DestoryProjectile (lifeTime);
	}

	void DestoryProjectile(float time) {
		//Instantiate (destroyEffect , transform.position, Quaternion.identity);
		Destroy(Instantiate(SFX, transform.position, Quaternion.identity),time);
        Destroy(gameObject, time);
        
	}
}
