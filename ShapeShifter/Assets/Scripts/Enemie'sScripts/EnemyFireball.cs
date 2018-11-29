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
        Vector3 norm = new Vector3(direction.normalized.x, 0, direction.normalized.y);
        Debug.Log(direction);
        Debug.Log(Quaternion.LookRotation(Vector3.forward));
        //transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.right);

        var rad = Mathf.Atan2(direction.y, direction.x);
        var deg = rad * (180 / Mathf.PI);

        transform.rotation = Quaternion.Euler(0, 0, deg + 270);

        //transform.rotation = Quaternion.Euler(0, 0, direction.x);
        //transform.LookAt(GameObject.Find("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
        
        //RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, direction, distance, whatIsSolid);
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitinfo.collider != null) {
			if (hitinfo.collider.CompareTag("Player")) {
                Debug.Log("Player hit!!!");
                Audio.PlaySound("BowHit");
                hitinfo.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                DestroyProjectile(0);
			}
			// DestroyProjectile(0);
		}
        
		//transform.Translate(direction.normalized * speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        Destroy(Instantiate(SFX, transform.position, Quaternion.identity), 0.3f);
    }

	void DestroyProjectile(float time) {
        //Instantiate (destroyEffect , transform.position, Quaternion.identity);
		Destroy(Instantiate(SFX, transform.position, Quaternion.identity), time);
        Destroy(gameObject, time);
	}
}
/*
 * fireball invisible
 * not going towards player
 * 
 */ 
