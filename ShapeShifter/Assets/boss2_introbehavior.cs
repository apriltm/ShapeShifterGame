using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2_introbehavior : StateMachineBehaviour {
    public GameObject bateffect;
    private GameObject bossp2;
    private Vector2 batspawn;
    public float timer;
    

	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        bossp2 = GameObject.FindGameObjectWithTag("bossp2");

        batspawn = new Vector2(bossp2.transform.position.x -1, bossp2.transform.position.y - 2.5f);

    }

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (timer <= 0)
        {
            animator.SetTrigger("idle");
        }
        else
        {
            timer = timer - Time.deltaTime;
            Destroy(Instantiate(bateffect, batspawn, bossp2.transform.rotation), 1.5f);
        }



        
    }
	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
	    
	}

	
}
