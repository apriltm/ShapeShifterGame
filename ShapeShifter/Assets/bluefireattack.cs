using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluefireattack : MonoBehaviour {

    public GameObject bluefire;
    private GameObject attackposfire;
    private SpriteRenderer firerender;
    private GameObject boss2;
    private GameObject player;
    private float xdistance;
    bool flipped = false;

    void Start()
    {
        boss2 = GameObject.FindGameObjectWithTag("bossp2");
        player = GameObject.FindGameObjectWithTag("Player");
        attackposfire = GameObject.Find("breathfirepos");
        firerender = bluefire.GetComponent<SpriteRenderer>();
        xdistance = boss2.transform.position.x - player.transform.position.x;
    }

    void breathfireattack()
    {
        Debug.Log("PLAYER X POSITION IS..: " + player.transform.position.x + "BOSS X POSITION IS......" + boss2.transform.position.x);
        Vector2 flippedattack = new Vector2(boss2.transform.position.x + (3.55f), boss2.transform.position.y - 2.2f);

        if (player.transform.position.x < boss2.transform.position.x)
        {
            firerender.flipX = false;
            flipped = false;
            
        }
        else
        {
            firerender.flipX = true;
            flipped = true;
           
            
        }

        if (flipped)
        {
            Destroy(Instantiate(bluefire, flippedattack, attackposfire.transform.rotation), 1.0f);
        }
        else
        {
            Destroy(Instantiate(bluefire, attackposfire.transform.position, attackposfire.transform.rotation), 1.0f);
        }

        

    }
}
