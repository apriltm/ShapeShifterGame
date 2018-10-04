using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

    [SerializeField]
    private Enemy enemy;

    // Target player when enemy spots player
    private void OnTriggerEnter2D(Collider2D other)
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
            enemy.Target = null;
        }
    }
}
