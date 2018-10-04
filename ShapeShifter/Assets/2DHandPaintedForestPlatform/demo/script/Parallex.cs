using UnityEngine;
using System.Collections;

public class Parallex : MonoBehaviour
{
	public Transform[] backGrounds;

	private float[] scales;

	public float smoothness = 1f;

	private Transform cam;

	private Vector3 prevCamPosition;

	void Awake ()
	{
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start ()
	{
		prevCamPosition = cam.position;

		scales = new float[backGrounds.Length];

		for (int i=0; i<backGrounds.Length; i++) {
			scales [i] = backGrounds [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{	
		for (int i=0; i<backGrounds.Length; i++) {
			float parallex = (prevCamPosition.x - cam.position.x) * scales [i];
			float backgroundTargetPosX = backGrounds [i].position.x + parallex;
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, 
			                                          backGrounds [i].position.y, 
			                                          backGrounds [i].position.z);

			backGrounds [i].position = Vector3.Lerp (backGrounds [i].position, 
			                                       backgroundTargetPos, 
			                                       smoothness * Time.deltaTime);
		}

		prevCamPosition = cam.position;
	}
}
