using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Rigidbody2D enemyRigidbody;
    public int unitsToMove = 5;
    public float speed = 500;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
/*
 * Variables that would affect different enemy movement
 * View distance: how far away the enemy can see the player from
 * Speed
 * 
 * Archer would stay in the same spot for a couple shots
 */