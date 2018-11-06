using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemy : Enemy {

    private float fireRate = 3;
    private float timeSinceLastFire = 0;
    
    public GameObject projectile;
    public Transform shotPoint;

    private GameObject target;

    // fireball cooldown
    bool canFire
    {
        get
        {
            return timeSinceLastFire < fireRate;
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
        timeSinceLastFire += Time.deltaTime;
	}
    // Gets position of player and shoots a fireball towards that location
    private void ShootFireball()
    {
        if (canFire) {
            Instantiate(projectile);
            timeSinceLastFire = 0;
        }
    }
}
