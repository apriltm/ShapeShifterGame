using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    [SerializeField]
    private GameObject other;

	private void Awake () {
        foreach (Collider2D a in GetComponents<Collider2D>())
        {
            foreach(Collider2D b in other.GetComponents<Collider2D>())
            {
                Physics2D.IgnoreCollision(a, b, true);
            }
        }
	}
}
