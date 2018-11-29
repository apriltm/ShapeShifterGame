using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : Enemy {
    
    public GameObject projectile;
    private Rigidbody2D rb;

    // Use this for initialization
    public override void Start () {
        Debug.Log("Mage start");
        base.Start();

        // hacky fix because mage wasnt facing the right direction
        facingRight = !facingRight;

        rb = GetComponent<Rigidbody2D>();

    }
    
	// Update is called once per frame
	void Update () {
        // prevents sliding on slopes
        rb.velocity = new Vector2(0, rb.velocity.y);

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
        Vector3 difference = GameObject.Find("Player").transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //convert angle to degrees
        var rotation = Quaternion.Euler(0f, 0f, rotZ + 0);

        Vector3 relativePos = GameObject.Find("Player").transform.position - transform.position;
        
        Ray ray = new Ray(transform.position, relativePos);

        Instantiate(projectile, transform.position, rotation);
    }
    
	IEnumerator HurtBlinker(float hurtTime)
    {
		MyAnimator.SetLayerWeight (1, 1f);
		yield return new WaitForSeconds(hurtTime);
		MyAnimator.SetLayerWeight (1, 0f);
	}
}
