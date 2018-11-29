using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitskull : MonoBehaviour {
    public GameObject skull;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        skull = GameObject.FindGameObjectWithTag("Skull");
        
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Skull")){
            Debug.Log("HITTING SKULL");
        }
    }

}
