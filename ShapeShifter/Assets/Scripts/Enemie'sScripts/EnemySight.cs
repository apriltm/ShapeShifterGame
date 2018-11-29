using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be attached to the 'Sight' collider, not the enemy itself.
public class EnemySight : MonoBehaviour {

    [SerializeField]
    private Enemy enemy;

    // Target player when enemy spots player
    // TODO: I think this should be trigger enter instead
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = other.gameObject;
        }
    }

    // Stop targeting player
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Can't see player");
            enemy.Target = null;
        }
    }
}
