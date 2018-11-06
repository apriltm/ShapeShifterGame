using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscontroller : MonoBehaviour {
    //public float lookradius = 10f;
    // Use this for initialization

    public Animator bossanimator;
    public GameObject player;
    public Vector2 target;
    public float speed;
    public float rangeofattack;
    public bool isattacking;
    
    
	void Start () {

        isattacking = false;
       
	}
	
	// Update is called once per frame
	void Update () {
       
        Move();

        if (inrangetoattack())
        {
            Attack();
            isattacking = true;
        }
        else
        {
            isattacking = false;
        }
        
	}

    public void Move()
    {
        if (isattacking == false) { 
        target = GetTarget();
        bossanimator.SetTrigger("run");
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    public void Attack()
    {
        
        bossanimator.SetTrigger("attack");
        Idle();
  
    }

    public void Idle()
    {
        bossanimator.SetTrigger("idle");
    }

    public Vector2 GetTarget()
    {
        Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
        return target;

    }


    public bool inrangetoattack()
    {
        float diff = (player.transform.position.x - transform.position.x);

        if (diff <= rangeofattack)
        {
            return true;
        }
        else
        {
            return false;
        }
        

      
    }

    

}



    /*
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradius);
    }
    */


