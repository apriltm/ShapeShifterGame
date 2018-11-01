using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(Speed* Time.deltaTime , 0);

            pos += transform.rotation * velocity;

            transform.position = pos;
	}

    private void OnTriggerEnter(Collider2D col)
    {
        if(col.tag == "Edge")
        {
            Speed = Speed*-1f;
        }
    }
}
