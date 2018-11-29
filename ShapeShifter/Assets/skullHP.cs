using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullHP : MonoBehaviour {

    public float health;
    private GameObject arrow;
    public GameObject contactexplode;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        arrow = GameObject.FindGameObjectWithTag("PlayerArrow");
        
        if (arrow != null)
        {
            if (Vector3.Distance(gameObject.transform.position, arrow.transform.position) <= 1.5f)
            {
                Destroy(Instantiate(contactexplode, transform.position, Quaternion.identity), 2.0f);
                Destroy(gameObject);
                Destroy(arrow);

            }
        }
       
	}

    public void TakeDamage(float dam)
    {
        health = health - dam;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
