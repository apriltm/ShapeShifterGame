using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public Transform player;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position = new Vector3 (player.position.x, this.transform.position.y, 
		                                      this.transform.position.z);


	}
}
