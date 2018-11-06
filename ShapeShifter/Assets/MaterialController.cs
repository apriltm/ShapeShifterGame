using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour {

    public SpriteRenderer main, knight, mage, archer, NYAN, arrow, shield;
    public Material Default;
    public Material Dark;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D col) {

        main.material = Dark;
        knight.material = Dark;
        mage.material = Dark;
        archer.material = Dark;
        NYAN.material = Dark;
        arrow.material = Dark;
        shield.material = Dark;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        main.material = Default;
        knight.material = Default;
        mage.material = Default;
        archer.material = Default;
        NYAN.material = Default;
        arrow.material = Default;
        shield.material = Default;
    }


}
