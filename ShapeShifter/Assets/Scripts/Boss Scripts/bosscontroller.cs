using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscontroller : MonoBehaviour {
    //public float lookradius = 10f;
    // Use this for initialization

    public Animator bossanimator;
    public GameObject player;
    public Vector3 playerpos;
    public float speed;
    public float rangeofattack;
    public bool isattacking;
    public bool isidling;
    public bool ismoving;
    public SpriteRenderer bossrender;
    public float movespeed;
    public Transform attackPos;
    public LayerMask Player;
    public float attackRange;
    public int health;
    public bool isdead = false;

    void Start () {

      
       
	}
	
	// Update is called once per frame
	void Update () {
        
        if (health <= 0)
        {
            isdead = true;
        }
        
	}

    public void giveDamage(int dam)
    {

        Audio.PlaySound("EnemyAttack");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Player);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<PlayerHealth>().TakeDamage(dam);
        }

    }

    public void TakeDamage(int damage)
    {
        
        if (!isdead)
        {
            health -= damage;
            Audio.PlaySound("EnemyHurt");
            Debug.Log("ENEMY HEALTH IS: " + health);
        }
        else
        {
            Audio.PlaySound("EnemyHurt");

        }
    }

    public void Move()
    {
        playerpos = GetTarget();
        bossanimator.SetTrigger("run");
        if (transform.position.x - playerpos.x < 0)
        {
            bossrender.flipX = false;
            transform.Translate(playerpos * (movespeed * Time.deltaTime));
        }
        else
        {
            bossrender.flipX = true;
            transform.Translate(-(playerpos) * (movespeed * Time.deltaTime));
        }
       
    }


    public void Attack()
    {
        
        bossanimator.SetTrigger("attack");
        
    }

    public void Idle()
    {
        bossanimator.SetTrigger("idle");
    }

    public Vector2 GetTarget()
    {
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, 0);

        return (target);

    }

    public float GetDistancetoPlayer()
    {
        Vector2 target = GetTarget();
        float distance = target.x - transform.position.x;
        if(distance < 0)
        {
            distance = distance * (-1);
        }

        return distance;
    }


    

}



    /*
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradius);
    }
    */


