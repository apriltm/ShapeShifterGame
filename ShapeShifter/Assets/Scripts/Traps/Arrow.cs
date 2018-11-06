using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    PlayerHealth player;
	float maxSpeed = 3.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
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
        if (player.currentHealth > 0)
        {
            if (col.CompareTag("Player"))
            {

                player.TakeDamage(20);
                Destroy(gameObject);
            }
        }

    }
}
