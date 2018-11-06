using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour {

    public float speed;
    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // hurt player
            Destroy(gameObject);
        }
    }

    /*
    public float lifeTime;
    public float distance;
    public int damage;

    public LayerMask whatIsSolid;
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("ENEMY HIT!");
                hitinfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile(0);
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
        DestroyProjectile(lifeTime);
    }*/

    void DestroyProjectile(float time)
    {
        //Instantiate (destroyEffect , transform.position, Quaternion.identity);
        Destroy(gameObject, time);
    }
}
