using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    public Animator cam;

	public void shake()
    {
        cam.SetTrigger("shake");
    }
}
