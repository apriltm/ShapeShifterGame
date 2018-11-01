using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour {

    public GameObject ArrowPrefab;
    private float time = 0f;
    public float TimeDelay;
    public float ArrowDeath;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(time < Time.time)
        {
            Destroy(Instantiate(ArrowPrefab, transform.position,  transform.rotation), ArrowDeath);
            time = Time.time + TimeDelay;
        }
	}
}
