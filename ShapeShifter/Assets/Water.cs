using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Water : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb;
    private PlayerController player;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
 
        rb.drag = 5f;
        player = gameObject.GetComponent<PlayerController>();
        player.Invoke("Dies", 5f);


    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.CompareTag("Player")){
            rb.gravityScale = 3.55f;
        }
    }

}
