using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    PlayerHealth player;
	float maxSpeed = 3.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (maxSpeed * Time.deltaTime, maxSpeed * Time.deltaTime, 0);

		pos += transform.rotation * velocity;

		transform.position = pos;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player = col.gameObject.GetComponent<PlayerHealth>();
            if (player.currentHealth > 0)
            {
                player.TakeDamage(20);
                Destroy(gameObject);
            }
        }

    }
}
