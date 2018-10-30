using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;
	public float speed;
	public Transform currentPoint;
	public Transform[] points;

	public int pointSelections;

	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelections];
	}
	
	// Update is called once per frame
	void Update () {

		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * speed);

		if (platform.transform.position == currentPoint.position) {
			pointSelections++;

			if (pointSelections == points.Length) {
				pointSelections = 0;
			}

			currentPoint = points [pointSelections];
		}

	}
}
