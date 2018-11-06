using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYAN : MonoBehaviour {

    public GameObject NYANCAT;
    public GameObject SS;

	// Use this for initialization
	void Start () {
        NYANCAT.SetActive(false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "darkness")
        {
            Audio.PlaySound("Shift");
            Instantiate(SS, NYANCAT.transform.position, transform.rotation = Quaternion.identity);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "darkness")
        {
            NYANCAT.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "darkness")
        {
            NYANCAT.SetActive(false);
            Audio.PlaySound("Shift");
            Instantiate(SS, NYANCAT.transform.position, transform.rotation = Quaternion.identity);
        }
    }
}
