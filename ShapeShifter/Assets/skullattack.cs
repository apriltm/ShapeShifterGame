using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullattack : MonoBehaviour {

    public GameObject skulls;
    public GameObject spawningeffect;
    private SpriteRenderer skullrender;
    private GameObject skullattackposright;
    private GameObject skullattackposleft;
    private GameObject boss2;
    private GameObject player;

    void Start()
    {
        boss2 = GameObject.FindGameObjectWithTag("bossp2");
        player = GameObject.FindGameObjectWithTag("Player");
        skullattackposright = GameObject.Find("skullpositionright");
        skullattackposleft = GameObject.Find("skullpositionleft");
        skullrender = skulls.GetComponent<SpriteRenderer>();
    }

    void skullfireattack()
    {
        if (player.transform.position.x < boss2.transform.position.x)
        {
            skullrender.flipX = false;
            Instantiate(skulls, skullattackposright.transform.position, skullattackposright.transform.rotation);
            Destroy(Instantiate(spawningeffect, skullattackposright.transform.position, skullattackposright.transform.rotation), 1.0f);
        }
        else
        {
            skullrender.flipX = true;
            Instantiate(skulls, skullattackposleft.transform.position, skullattackposleft.transform.rotation);
            Destroy(Instantiate(spawningeffect, skullattackposleft.transform.position, skullattackposleft.transform.rotation), 1.0f);
        }
    }
}


