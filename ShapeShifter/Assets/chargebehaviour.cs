using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargebehaviour : StateMachineBehaviour {

	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        
    }

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        animator.SetTrigger("attack");

    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
	}

	
}
