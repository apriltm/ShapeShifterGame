using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rickedRolled : MonoBehaviour {

    public GameObject rick;


	// Use this for initialization
	void Start () {
        rick.SetActive(false);	
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D col) {
        if (col.tag == "Player")
        {
            rick.SetActive(true);
            
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Audio.PlaySound("rolled");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            rick.SetActive(false);

        }
    }
}
