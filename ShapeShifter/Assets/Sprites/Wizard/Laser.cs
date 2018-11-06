using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float laserSpeed;
	public int damage;
    public Rigidbody2D shootDown;
    void Start()
    {
        shootDown.velocity = new Vector2(0.0f, 0f) ;
        shootDown.velocity = transform.up * laserSpeed;
    }

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("Enemy")){
			other.GetComponent<Enemy> ().TakeDamage (damage);
		}
	}
}
