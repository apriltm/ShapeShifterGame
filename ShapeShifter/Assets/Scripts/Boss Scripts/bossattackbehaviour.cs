using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattackbehaviour : StateMachineBehaviour {

    private Transform playerpos;
    private SpriteRenderer playerrender;
    public float speed;
    private float distance;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        animator.SetInteger("howmanyattacks", animator.GetInteger("howmanyattacks") + 1);
        Debug.Log("ATTACK # " + animator.GetInteger("howmanyattacks"));
        
    }
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        if (animator.GetBool("facingright"))
        {
            Vector2 target = new Vector2(playerpos.position.x + 10f, animator.transform.position.y);
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            Vector2 target = new Vector2(playerpos.position.x - 10f, animator.transform.position.y);
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        }
        

        distance = animator.transform.position.x - playerpos.position.x;
        if (distance < 0)
        {
            
            distance = distance * (-1);
        }

       
        
        if ((distance > 5) && (animator.GetInteger("howmanyattacks") < 3))
        {
           animator.SetTrigger("run");
                
        }else if (animator.GetInteger("howmanyattacks") >= 3)
        {
            animator.SetTrigger("idle");
            animator.SetInteger("howmanyattacks", 0);
        }
        
       
        
    }

	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
