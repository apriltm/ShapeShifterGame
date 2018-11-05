using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runbehaviour : StateMachineBehaviour {

    private Transform playerpos;
    public float speed;

    public GameObject boss;


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("PLAYER POS" + playerpos.position.x);
        Debug.Log("BOSS POS" + animator.transform.position.x);
        Vector2 target = new Vector2(playerpos.position.x, playerpos.position.y);

        boss.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
	}

	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	
	
}
