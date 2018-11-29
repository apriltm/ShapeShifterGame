using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : Enemy {
    
    public GameObject projectile;
    

    // Use this for initialization
    public override void Start () {
        Debug.Log("Mage start");
        base.Start();

        // hacky fix because mage wasnt facing the right direction
        facingRight = !facingRight;
	}
    
	// Update is called once per frame
	void Update () {
        if (!IsDead) {
            currentState.Execute();
            LookAtTarget();
            if (Attack == true)
            {
                Attack = false;
                ShootFireball();
            }
        }
	}

    public void ShootFireball()
    {
        
        Vector3 relativePos = GameObject.Find("Player").transform.position - transform.position;
        //Debug.DrawRay(transform.position, relativePos, Color.red, 3);
        
        Ray ray = new Ray(transform.position, relativePos);
        // the second argument, upwards, defaults to Vector3.up
        //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        Debug.Log("Shoot Fireball");
        
        Instantiate(projectile, transform.position, transform.rotation);
        //Instantiate(projectile, transform.position, Quaternion.LookRotation(ray.direction));
    }
    
	IEnumerator HurtBlinker(float hurtTime)
    {
		MyAnimator.SetLayerWeight (1, 1f);
		yield return new WaitForSeconds(hurtTime);
		MyAnimator.SetLayerWeight (1, 0f);
	}
}
