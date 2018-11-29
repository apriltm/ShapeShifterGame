using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattackbehaviour : StateMachineBehaviour {

    private Transform playerpos;
    private SpriteRenderer playerrender;
    public float speed;
    private float distance;
    private int rand;
    private GameObject boss;
    private Vector2 target;
    bosscontroller controlboss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        rand = Random.Range(0, 2);
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator.SetInteger("howmanyattacks", animator.GetInteger("howmanyattacks") + 1);
        Debug.Log("ATTAACKS " + animator.GetInteger("howmanyattacks"));

        boss = GameObject.FindGameObjectWithTag("boss");
        controlboss = boss.GetComponent<bosscontroller>();

        if (animator.GetBool("facingright"))
        {
            target = new Vector2(playerpos.position.x + 7f, boss.transform.position.y);
           
        }
        else
        {
            target = new Vector2(playerpos.position.x - 7f, boss.transform.position.y);
           
        }
    }
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        boss.transform.position = Vector2.MoveTowards(boss.transform.position, target, speed * Time.deltaTime);



        distance = boss.transform.position.x - playerpos.position.x;
        if (distance < 0)
        {
            
            distance = distance * (-1);
        }

       

        if (distance > 5)
        {
           animator.SetTrigger("run");
           
                
        }

        



    }

	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        controlboss.TakeDamage(50);
        Debug.Log("BOSS HP IS: " + controlboss.health);
     

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
