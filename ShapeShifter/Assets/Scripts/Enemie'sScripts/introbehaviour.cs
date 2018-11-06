using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introbehaviour : StateMachineBehaviour {

    private int rand;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state. //Like the start funciton.
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        /*
        rand = Random.Range(0, 3);

        if (rand == 0)
        {
            animator.SetTrigger("idle");
        }else if (rand == 1)
        {
            animator.SetTrigger("run");
        }
        else
        {
            animator.SetTrigger("specialattack");
        }
        */

        animator.SetTrigger("run");
        
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks. //Every frame
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	
}
