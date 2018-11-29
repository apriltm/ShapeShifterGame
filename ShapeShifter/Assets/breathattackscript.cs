using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breathattackscript : MonoBehaviour {
    PlayerHealth playerhp;
    public float damage;
	// Use this for initialization
	void Start () {
        playerhp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerhp.TakeDamage(damage);
        }
          
    }
}
