using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    public int MaxAmmo;
    public int CurrentAmmo;


	// Use this for initialization
	void Start () {
        CurrentAmmo = 10;
	}
	
	// Update is called once per frame
	public void ShootAmmo () {
        CurrentAmmo -= 1;
        Debug.Log("Ammo: " + CurrentAmmo);
	}

    public void addAmmo(int amount)
    {
        CurrentAmmo += amount;
        Debug.Log("Ammo: " + CurrentAmmo);
    }
}
