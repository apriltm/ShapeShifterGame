using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossP2Health : MonoBehaviour
{
    public float health;
    private GameObject arrow;
    private GameObject fireball;
    Fireball fireballscript;
    public GameObject contactexplode;
    public Animator bossanimator;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        arrow = GameObject.FindGameObjectWithTag("PlayerArrow");
        fireball = GameObject.FindGameObjectWithTag("PlayerFireball");

        if (arrow != null)
        {
            fireballscript = arrow.GetComponent<Fireball>();
            if (Vector3.Distance(gameObject.transform.position, arrow.transform.position) <= 1.5f)
            {
                TakeDamage(fireballscript.damage);
                Debug.Log("BOSS HP IS: " + health);
                Destroy(arrow);

            }
        }


        if (fireball!= null)
        {
            fireballscript = fireball.GetComponent<Fireball>();
           // Debug.Log("DISTANCE BETWEEN FIREBALL AND BOSS IS: " + Vector3.Distance(gameObject.transform.position, fireball.transform.position));
            if (Vector3.Distance(gameObject.transform.position, fireball.transform.position) <= 1f)
            {
               
                TakeDamage(fireballscript.damage);
                Debug.Log("BOSS HP IS: " + health);
                Destroy(fireball);
                Destroy(Instantiate(contactexplode, transform.position, Quaternion.identity), 2.0f);
               

            }
        }






    }

    public void TakeDamage(float damage)
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
        bossanimator.SetTrigger("death");
    }
}
