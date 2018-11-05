using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectForm : MonoBehaviour {

    public GameObject SE;
    public GameObject Main, Knight, Mage, Archer;



    public int PlayerSelect;

    // Use this for initialization
    void Start() {
        PlayerSelect = 1;
    }

    // Update is called once per frame
    void Update() {
        SelectF();
        Shift();
    }

    void SelectF() {
        if (Input.GetButtonDown("Base") && PlayerSelect != 1) { //Grab input and then select a model for the player 
            Instantiate(SE, transform.position, transform.rotation = Quaternion.identity);
            Audio.PlaySound("Shift");
            PlayerSelect = 1;
        } else if (Input.GetButtonDown("Knight") && PlayerSelect != 2) {
            Instantiate(SE, transform.position, transform.rotation = Quaternion.identity);
            Audio.PlaySound("Shift");
            PlayerSelect = 2;
        } else if (Input.GetButtonDown("Mage") && PlayerSelect != 3) {
            Instantiate(SE, transform.position, transform.rotation = Quaternion.identity);
            Audio.PlaySound("Shift");
            PlayerSelect = 3;
        } else if (Input.GetButtonDown("Archer") && PlayerSelect != 4)
        {
            Instantiate(SE, transform.position, transform.rotation = Quaternion.identity);
            Audio.PlaySound("Shift");
            PlayerSelect = 4;
        }


    }

    void Shift()
    {
        if (PlayerSelect == 1)
        {

            Main.SetActive(true);
            Knight.SetActive(false);
            Mage.SetActive(false);
            Archer.SetActive(false);
        }
        else if (PlayerSelect == 2)
        {
            Main.SetActive(false);
            Knight.SetActive(true);
            Mage.SetActive(false);
            Archer.SetActive(false);
        }
        else if (PlayerSelect == 3)
        {
            Main.SetActive(false);
            Knight.SetActive(false);
            Mage.SetActive(true);
            Archer.SetActive(false);
        }
        else if (PlayerSelect == 4)
        {
            Main.SetActive(false);
            Knight.SetActive(false);
            Mage.SetActive(false);
            Archer.SetActive(true);
        }


    }
}
