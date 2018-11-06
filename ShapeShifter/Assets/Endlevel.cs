using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endlevel : MonoBehaviour {

    public bool isit;

	// Use this for initialization
	void Start () {
        isit = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isit = true;
            Debug.Log("END");
        }
    }


}
