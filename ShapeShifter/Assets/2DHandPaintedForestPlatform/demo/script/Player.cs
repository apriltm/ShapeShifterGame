using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float speed = 1;

	private bool isJumping, isFalling = false;
	public float jumpPower = 100;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (h, 0.0f, 0);
		GetComponent<Rigidbody2D> ().velocity = movement * speed;

	}
}
