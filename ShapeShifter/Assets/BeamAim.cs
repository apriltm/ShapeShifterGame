using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAim : MonoBehaviour {

	public GameObject WarningShot;
	public GameObject Laser;
	public Transform LaserPoint;


	private float timeBtwShots;
	public float startTimeBtwShots;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector3 (mouse.x, transform.position.y, transform.position.z);

		if (timeBtwShots <= 0) {
			if (Input.GetMouseButtonDown (1)) {
				//player.animator3.SetTrigger ("BasicAtt");
				Destroy (Instantiate (WarningShot, LaserPoint.position, transform.rotation), 1.75f);
				//yield return new WaitForSeconds (.35f);
				Destroy (Instantiate (Laser, LaserPoint.position, transform.rotation), 5.0f);
				timeBtwShots = startTimeBtwShots;
			}
		} else {
			timeBtwShots -= Time.deltaTime;
		}

	}
}
