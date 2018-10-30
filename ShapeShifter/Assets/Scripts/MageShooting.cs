using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageShooting : MonoBehaviour
{

     public GameObject projectile;
     public Vector2 velocity;
     bool canShoot = true;
     public Vector2 offset = new Vector2(0.4f, 0.1f);
     public float cooldown = 1f;
     // Use this for initialization
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         if (Input.GetKey("f") && canShoot)
         {
           GameObject go = (GameObject)Instantiate(projectile,(Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
           go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
         }
     }

     IEnumerator CanShoot()
     {
         canShoot = false;
         yield return new WaitForSeconds(cooldown);
         canShoot = true;
     }
     /*
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }


        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    */
}
