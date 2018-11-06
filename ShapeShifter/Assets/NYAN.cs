using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYAN : MonoBehaviour {

    public GameObject NYANCAT;
    public GameObject SS_Prefab;
    


    // Use this for initialization
    void Start()
    {
        /*main.material = DefaultMat;
        knight.material = DefaultMat;
        mage.material = DefaultMat;
        archer.material = DefaultMat;*/
        NYANCAT.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("darkness"))
            Instantiate(SS_Prefab, NYANCAT.transform.position, transform.rotation = Quaternion.identity);
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("darkness"))
        {
            
            NYANCAT.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Instantiate(SS_Prefab, NYANCAT.transform.position, transform.rotation = Quaternion.identity);
        NYANCAT.SetActive(false);
    }

}
