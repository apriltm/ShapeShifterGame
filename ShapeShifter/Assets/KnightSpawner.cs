using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawner : MonoBehaviour {

    public GameObject point1, point2, point3, p4, p5 ;
    public GameObject Knight;
    public GameObject boss;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            
                Instantiate(Knight, point1.transform.position, point1.transform.rotation);
                Instantiate(Knight, point2.transform.position, point2.transform.rotation);
                Instantiate(Knight, point3.transform.position, point3.transform.rotation);
            Instantiate(Knight, p4.transform.position, p4.transform.rotation);
            Instantiate(boss, p5.transform.position, p5.transform.rotation);

        }
    }
}
