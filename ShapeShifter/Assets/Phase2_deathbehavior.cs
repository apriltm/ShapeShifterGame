using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2_deathbehavior : StateMachineBehaviour {
    private float timer = 3.06f;
    private GameObject boss2;
    public GameObject deatheffect1;
    public GameObject deatheffect2;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        boss2 = GameObject.FindGameObjectWithTag("bossp2");
	}

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    if (timer <= 0)
        {
            Destroy(Instantiate(deatheffect1, boss2.transform.position, boss2.transform.rotation), 3.0f);
            Destroy(Instantiate(deatheffect2, boss2.transform.position, boss2.transform.rotation), 3.0f);
            Destroy(boss2);
        }
        else
        {

            timer = timer - Time.deltaTime;
        }
	}
    
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	
	
}
