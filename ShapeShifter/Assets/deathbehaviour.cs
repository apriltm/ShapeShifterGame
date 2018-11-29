using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathbehaviour : StateMachineBehaviour {
    private GameObject deathpoint;
    private GameObject boss;
    public GameObject deatheffect1;
    public GameObject bossphase2;
    public float speedofdying;
    private Vector2 target;
    private Vector2 batspawn;
    private Vector2 bossspawn;
    bosscontroller controlboss;
    public float timer = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deathpoint = GameObject.Find("deathpoint");
        boss = GameObject.FindGameObjectWithTag("boss");
        controlboss = boss.GetComponent<bosscontroller>();
        

        batspawn = new Vector2(boss.transform.position.x + 1, boss.transform.position.y - 2);
        bossspawn = new Vector2(boss.transform.position.x + 1, boss.transform.position.y + 3);
        Instantiate(bossphase2,  bossspawn, boss.transform.rotation);



    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            Destroy(boss);
        }
        else
        {
            timer = timer - Time.deltaTime;
            Destroy(Instantiate(deatheffect1, batspawn, boss.transform.rotation), .8f);
        }

        

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
