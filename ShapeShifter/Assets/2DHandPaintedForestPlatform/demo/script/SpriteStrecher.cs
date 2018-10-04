using UnityEngine;
using System.Collections;

public class SpriteStrecher : MonoBehaviour
{
	public Transform left;

	public Transform right;

	// Use this for initialization
	void Start ()
	{
	    
		this.transform.localScale = new Vector3 ((left.position.x - right.position.x) / this.GetComponent<Renderer> ().bounds.size.x,
		                                         1, 1);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
