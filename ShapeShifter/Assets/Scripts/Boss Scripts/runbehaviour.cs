using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runbehaviour : StateMachineBehaviour {
    private Transform playerpos;
    private float distance;
    private SpriteRenderer bossrender;
    public float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossrender = GameObject.FindGameObjectWithTag("boss").GetComponent<SpriteRenderer>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector2 target = new Vector2(playerpos.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        
        distance = animator.transform.position.x - playerpos.position.x;
        if (distance < 0)
        {
            bossrender.flipX = false;
            animator.SetBool("facingright", true);
            distance = distance * (-1);
        }
        else
        {
            animator.SetBool("facingright", false);
            bossrender.flipX = true;
        }

        if (distance <= 5)
        {
            
            animator.SetTrigger("attack");
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
