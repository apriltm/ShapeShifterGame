using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour {

	public float maxMana= 100.0f;
	public float currentMana;
    public Image CurrrentManaBar;
    public Text ManaText;
    public float restoreRate;

	//private PlayerController player;

	//public Image currentManaBar;
	


	// Use this for initialization
	void Start () {
		currentMana = maxMana;
        StartCoroutine(restoreMana());
        UpdateManaBar();
        //player = gameObject.GetComponent<PlayerController> ();

    }
	
	// Update is called once per frame
	void Update () {

		//Debug.Log ("Current mana is at " + currentMana);
        
		//Invoke ("RestoreMana", 5.0f);
	}

    private void FixedUpdate()
    {
        
    }

    public void UseMana(int cost) {
		currentMana -= cost;
        UpdateManaBar();
    }


    IEnumerator restoreMana()
    {
        while (true)
        { // loops forever...
            if (currentMana < 100)
            { // if health < 100...
                currentMana += restoreRate; // increase health and wait the specified time
                yield return new WaitForSeconds(1);
            }
            else
            { // if health >= 100, just yield 
                yield return null;
            }
            UpdateManaBar();
        }
    }

    public void UpdateManaBar()
    {
        float ratio = currentMana / maxMana;
        CurrrentManaBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        //HPText.text = currentHealth.ToString();

    }
}
