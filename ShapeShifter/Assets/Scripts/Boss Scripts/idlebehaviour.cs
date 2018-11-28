using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idlebehaviour : StateMachineBehaviour {

    public float idletime;
    float idletimer;
    private int rand;
    float truedistance;
    private GameObject boss;
    private GameObject player;
    
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        rand = Random.Range(0, 2);
        boss = GameObject.FindGameObjectWithTag("boss");
        player = GameObject.FindGameObjectWithTag("Player");
        animator.SetInteger("howmanyattacks", 0);
    }
    
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        truedistance = Vector3.Distance(boss.transform.position, player.transform.position);

        if (idletimer <= 0)
        {
            idletimer = idletime;
            
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
