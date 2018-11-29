using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2_skullattackbehavior : StateMachineBehaviour {
    private float timetoendattack = 2.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (timetoendattack <= 0)
        {
            timetoendattack = 2.2f;
            animator.SetTrigger("idle");
        }
        else
        {
            timetoendattack -= Time.deltaTime;
        }
    }

	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	
	
}
