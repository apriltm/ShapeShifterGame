using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idlebehaviour : StateMachineBehaviour {

    public float idletimer;
    
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
    }
    
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (idletimer <= 0)
        {
            idletimer = 3;
            animator.SetTrigger("run");
        }
        else
        {
            idletimer -= Time.deltaTime;
        }
            
        
    }

	 
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        


    }

	
}
