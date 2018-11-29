using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public float distance;
	public int damage;
    //public GameObject SFX;

	public LayerMask whatIsSolid;

    private Vector3 playerPosition;
    private Vector3 direction;
    
    private Vector3 lastPos;

    // Use this for initialization
    void Start()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        direction = playerPosition - transform.position;
        
        Debug.Log("Fireball Created");
        Debug.DrawRay(transform.position, direction, Color.red, 3);

        var rad = Mathf.Atan2(direction.y, direction.x);
        var deg = rad * (180 / Mathf.PI);

        transform.rotation = Quaternion.Euler(0, 0, deg + 270);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitinfo.collider != null) {
			if (hitinfo.collider.CompareTag("Player")) {
                Debug.Log("Player hit!!!");
                Audio.PlaySound("BowHit");
                hitinfo.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                DestroyProjectile(0);
			}
		}
        
        // Moves the fireball
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Particle Effects
        
        //Destroy(Instantiate(SFX, transform.position, Quaternion.identity), 0.3f);
    }

	void DestroyProjectile(float time) {
		//Destroy(Instantiate(SFX, transform.position, Quaternion.identity), time);
        Destroy(gameObject, time);
	}
}
/*
 * fireball invisible
 * not going towards player
 * 
 */ 
