using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemy : Enemy {

    public float fireRate = 3;
    private float timeSinceLastFire;
    
    public GameObject projectile;
    
    // Use this for initialization
    public override void Start () {
        base.Start();
 
        attackRange = 10;
        timeSinceLastFire = 0;
	}

	// Update is called once per frame
	void Update () {
        if (!IsDead) {
            currentState.Execute();
            LookAtTarget();
        }
        if(timeSinceLastFire > fireRate)
        {
            Shoot();
        }
        else
        {
            timeSinceLastFire += Time.deltaTime;
        }
	}

    // Gets position of player and shoots a fireball towards that location
    private void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        timeSinceLastFire = 0;
    }
}
