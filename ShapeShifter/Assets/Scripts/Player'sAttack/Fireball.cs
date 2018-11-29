using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public float distance;
	public int damage;
    public GameObject SFX;
    private Enemy enemy;
	public LayerMask whatIsSolid;
    private skullHP skull;
    private BossP2Health bossP2Health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*RaycastHit2D hitinfo = Physics2D.Raycast (transform.position, transform.up, distance, whatIsSolid);
		if (hitinfo.collider != null) {
			if (hitinfo.collider.CompareTag ("Enemy")) {
                //Debug.Log ("ENEMY HIT!");
                Audio.PlaySound("BowHit");
                hitinfo.collider.GetComponent<Enemy> ().TakeDamage (damage);
			}
			DestoryProjectile (0);
		}*/

		transform.Translate (Vector2.up * speed * Time.deltaTime);
		DestoryProjectile (lifeTime);
	}

	void DestoryProjectile(float time) {
		//Instantiate (destroyEffect , transform.position, Quaternion.identity);
		Destroy(Instantiate(SFX, transform.position, Quaternion.identity),time);
        Destroy(gameObject, time);
        
	}

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.tag == "Skull")
        {
            skull = collision.gameObject.GetComponent<skullHP>();
            Destroy(gameObject);
            skull.TakeDamage(damage);
            
        }

        if(collision.tag == "bossp2")
        {
            Debug.Log("FUCK");
            bossP2Health = collision.GetComponent<BossP2Health>();
            bossP2Health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
