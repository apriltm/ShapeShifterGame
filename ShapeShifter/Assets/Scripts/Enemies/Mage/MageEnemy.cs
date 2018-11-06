using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * TODO: 
 *  larger attack range
 *  
 * 
 */
public class MageEnemy : Enemy {

    [SerializeField]
    GameObject fireball;

    float fireRate;
    float timeSinceFire;
    
    public GameObject projectile;
    public Transform shotPoint;

    private GameObject target;

    // fireball cooldown
    bool canFire
    {
        get
        {
            return timeSinceFire < fireRate;
        }
    }
    
    // Use this for initialization
    public override void Start () {
        base.Start();
 
        target = GameObject.Find("Player");
        attackRange = 10;
	}

	// Update is called once per frame
	void Update () {
        if (!IsDead) {
            currentState.Execute();
            LookAtTarget();
        }
	}
    // Gets position of player and shoots a fireball towards that location
    private void ShootFireball()
    {
        Vector2 targetPos = target.transform.position;
        Instantiate(projectile, shotPoint.position, transform.rotation);
    }
}
