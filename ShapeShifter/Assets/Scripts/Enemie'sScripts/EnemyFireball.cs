using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public float distance;
	public int damage;
    public GameObject SFX;

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


        //DestroyProjectile(lifeTime);

        //Vector3 playerPos = new Vector3(player.position.x, player.position.y + 1, player.position.z);

        // Aim bullet in player's direction.
        //transform.rotation = Quaternion.LookRotation(playerPos);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
        
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, direction, distance, whatIsSolid);
        if (hitinfo.collider != null) {
            // Debug.Log("Colliding with " + hitinfo.collider);
			if (hitinfo.collider.CompareTag ("Player")) {
                Debug.Log("Player hit!!!");
                Audio.PlaySound("BowHit");
                hitinfo.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                DestroyProjectile(0);
			}
			// DestroyProjectile(0);
		}
        
		transform.Translate (direction * speed * Time.deltaTime);
        
    }

	void DestroyProjectile(float time) {
        //Instantiate (destroyEffect , transform.position, Quaternion.identity);
		Destroy(Instantiate(SFX, transform.position, Quaternion.identity),time);
        Destroy(gameObject, time);
	}
}
/*
 * fireball invisible
 * not going towards player
 * 
 */ 
