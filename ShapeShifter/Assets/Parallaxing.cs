using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds; //Array (List) of all the back back- and forgrounds to be parallaxed
	private float[] parallaxScales; //The proportion of the camera's movement to move the BG by
	public float moving = 1.0f;

	private Transform cam;
	private Vector3 previousCamPos;
	// Use this for initialization

	void Awake() {  //called before Start(); Great for references. 
		// set up the cam reference
		cam = Camera.main.transform;
	}

	void Start () {
		// The previous frame had the current frame's camera position 
		previousCamPos = cam.position;

		//assigning coresponding parallaxScales
		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales [i] = backgrounds [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		// each BG
		for (int i = 0; i < backgrounds.Length; i++) {
			//the parallax is the opposite of the cam movement because the previous fram * by the scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			//set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			//create a target position which is the background's current position with it's target x position 
			Vector3 backgroundTargetPos = new Vector3 ( backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			//fad between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, moving * Time.deltaTime);
		}

		//set the Prev cam Pos to the cam's position at the of the frame
		previousCamPos = cam.position;
	}
}
