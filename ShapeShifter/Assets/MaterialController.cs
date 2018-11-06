using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour {

    
    public SpriteRenderer main, knight, mage, archer, shield, arrow, CAT;
    public Material DefaultMat, Defuse;
    

	// Use this for initialization
	void Start () {
        /*main.material = DefaultMat;
        knight.material = DefaultMat;
        mage.material = DefaultMat;
        archer.material = DefaultMat;*/
        
    }
    
    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == ("darkness"))
        {
            main.material = Defuse;
            knight.material = Defuse;
            mage.material = Defuse;
            archer.material = Defuse;
            shield.material = Defuse;
            arrow.material = Defuse;
            CAT.material = Defuse;
            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        main.material = DefaultMat;
        knight.material = DefaultMat;
        mage.material = DefaultMat;
        archer.material = DefaultMat;
        shield.material = DefaultMat;
        arrow.material = DefaultMat;
        CAT.material = DefaultMat;
       
    }

}
