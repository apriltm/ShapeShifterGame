using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullfollow : MonoBehaviour {

    private GameObject player;
    PlayerHealth playerhp;
    public GameObject contactexplode;
    public float damage;
    public float followspeed;

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
        if (collision.CompareTag("Player"))
        {
            Destroy(Instantiate(contactexplode, transform.position, Quaternion.identity), 2.0f);
            Destroy(gameObject);
            playerhp.TakeDamage(damage);
            
        }
        
    }
}
