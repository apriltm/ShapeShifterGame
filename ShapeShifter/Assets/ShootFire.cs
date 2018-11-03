using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour {

    public GameObject projectile;
    public Transform shotPoint;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
    }

}
