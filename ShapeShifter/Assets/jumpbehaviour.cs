using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpbehaviour : StateMachineBehaviour {
    private Transform playerpos;
    private float xdistance;
    private float ydistance;
    private SpriteRenderer bossrender;
    public float speed;
    public float jumpspeed;
    private GameObject boss;
    private Vector2 target;
    private Vector3 jumptarget;
    private float truedistance;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossrender = GameObject.FindGameObjectWithTag("boss").GetComponent<SpriteRenderer>();
        boss = GameObject.FindGameObjectWithTag("boss");
       

    }

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        xdistance = boss.transform.position.x - playerpos.position.x;

        target = new Vector2(playerpos.position.x, playerpos.position.y);

        if (xdistance < 0)
        {
            jumptarget = new Vector3(playerpos.position.x + (xdistance/2)  , boss.transform.position.y + 7.0f, playerpos.position.z);
        }
        else
        {
            jumptarget = new Vector3(playerpos.position.x - (xdistance / 2), boss.transform.position.y + 7.0f, playerpos.position.z);
        }
        

        truedistance = Vector3.Distance(playerpos.transform.position, boss.transform.position);
        
        
        boss.transform.position = Vector2.MoveTowards(boss.transform.position, jumptarget, jumpspeed * Time.deltaTime);
        
      
        ydistance = boss.transform.position.y - playerpos.position.y;

        if(ydistance < 0)
        {
            ydistance = ydistance * (-1);
        }
        else
        {
            //its positive
        }

        if (xdistance < 0)
        {
            bossrender.flipX = false;
            animator.SetBool("facingright", true);
            xdistance = xdistance * (-1);
        }
        else
        {
            animator.SetBool("facingright", false);
            bossrender.flipX = true;
        }


        
        if (xdistance <= 5 && ydistance <= 1 )
        {

            animator.SetTrigger("chargeforattack");
        }
        else if (xdistance > 5 && boss.transform.position.y == playerpos.transform.position.y)
        {
            animator.SetTrigger("run");
        }
    }

	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

    
	
}
