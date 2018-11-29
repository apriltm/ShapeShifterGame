using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossP2Health : MonoBehaviour
{
    public float health;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {

        if (health > 0)
        {
            health -= damage;
            Audio.PlaySound("EnemyHurt");

        }
        else
        {

            Die();
            Audio.PlaySound("EnemyHurt");

        }
    }

    void Die()
    {
        //nothing
    }
}
