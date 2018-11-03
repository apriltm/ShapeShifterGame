using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour {


    public int playerLvl;
    public int currentXP;

	// Use this for initialization
	void Start () {
        playerLvl = 13;
        currentXP = 19;
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddExp() {
		currentXP += 1;
		if (currentXP == 20) {
			Audio.PlaySound ("lvlUP");
			playerLvl = +1;
            currentXP = 0;
		}
		Debug.Log (playerLvl);
	}
}
