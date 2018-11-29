using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullfollow : MonoBehaviour {

    private GameObject player;
    public float skullHP;
    PlayerHealth playerhp;
    public GameObject contactexplode;
    public float damage;
    public float followspeed;
    private Fireball fire;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerhp = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (gameObject.transform.position != player.transform.position)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, followspeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Shot");
        if (collision.tag == "Player")
        {
            Destroy(Instantiate(contactexplode, transform.position, Quaternion.identity), 2.0f);
            Destroy(gameObject);
            playerhp.TakeDamage(damage);
            
        }

        /*if (collision.CompareTag("PlayerArrow"))
        {
            Debug.Log("COLLIDING WITH ARROW");
            fire = collision.gameObject.GetComponent<Fireball>();
            
            Destroy(Instantiate(contactexplode, transform.position, Quaternion.identity), 2.0f);
            Destroy(gameObject);
            fire.Die();
        }*/

        
    }

    public void TakeDamage(float dam)
    {
        skullHP = skullHP - dam;
        die();
    }

    void die()
    {
        if (skullHP <= 0)
        {
            Destroy(Instantiate(contactexplode, transform.position, Quaternion.identity), 2.0f);
            Destroy(gameObject);
        }
    }



}
