using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2_idlebehavior : StateMachineBehaviour {
    public float patroltime;
    private float settime;
    public float movementspeed;
    private float xdistance;
    private GameObject boss2;
    private Transform playerpos;
    private SpriteRenderer boss2render;
    private Vector3 leftpoint;
    private Vector3 rightpoint;
    private Vector3 leftshootingpoint;
    private Vector3 rightshootingpoint;
    bool goingleft = true;
    bool goingright = false;
    bool goingplayer = false;
    public bool playeronright = false;
    public bool playeronleft = false;
    int rand;
    int randomshootingpoint;
    public float distancetobreath;
    
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        leftpoint = GameObject.Find("leftpoint").transform.position;
        rightpoint = GameObject.Find("rightpoint").transform.position;
        leftshootingpoint = GameObject.Find("leftshootingpoint").transform.position;
        rightshootingpoint = GameObject.Find("rightshootingpoint").transform.position;
        boss2 = GameObject.FindGameObjectWithTag("bossp2");
        boss2render = boss2.GetComponent<SpriteRenderer>();
        playerpos = GameObject.FindGameObjectWithTag("Player").transform;
        rand = Random.Range(0,2);
        randomshootingpoint = Random.Range(0,2);
        settime = patroltime;
        

    }

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        xdistance = boss2.transform.position.x - playerpos.position.x;

        if(xdistance < 0)
        {
            boss2render.flipX = true;
            playeronright = true;
            playeronleft = false;

            
        }
        else
        {
            boss2render.flipX = false;
            playeronleft = true;
            playeronright = false;

            
        }

	   if (settime <= 0)
       {
            
            if (rand == 0)
            {
                //breathattack

                //findplayer
                Vector3 tempplayerpos = new Vector3(playerpos.position.x, playerpos.position.y + 3, boss2.transform.position.z);
                //Debug.Log("DISTANCE BETWEEN PLAYER AND BOSS IS: " + Vector3.Distance(playerpos.position, boss2.transform.position));
                if (Vector3.Distance(playerpos.position, boss2.transform.position) > distancetobreath)
                {
                    
                    boss2.transform.position = Vector2.MoveTowards(boss2.transform.position, tempplayerpos, 12 * Time.deltaTime);
                    if (Vector3.Distance(playerpos.position, boss2.transform.position) <= distancetobreath)
                    {
                        
                        animator.SetTrigger("breathattack");
                    }
                }
                
                
            }
            else
            {
                if (randomshootingpoint == 0)
                {
                  
                    //move to fireball RIGHT shooting position;
                    if (boss2.transform.position != rightshootingpoint)
                    {
                        boss2.transform.position = Vector3.MoveTowards(boss2.transform.position, rightshootingpoint, 12 * Time.deltaTime);
                    }
                    else
                    {
                        //boss in position
                        animator.SetTrigger("fireball");
                    }
                }
                else
                {
                    if (boss2.transform.position != leftshootingpoint)
                    {
                        boss2.transform.position = Vector3.MoveTowards(boss2.transform.position, leftshootingpoint, 12 * Time.deltaTime);
                    }
                    else
                    {
                        //boss in position
                        animator.SetTrigger("fireball");

                    }
                    //move to fireball left shooting position;
                }


            }
            
       }
       else
       {
            settime -= Time.deltaTime;
           
            if (goingleft)
            {
                
                Debug.Log("GOING LEFT.....");
                boss2.transform.position = Vector2.MoveTowards(boss2.transform.position, leftpoint, movementspeed * Time.deltaTime);
                if (boss2.transform.position == leftpoint)
                {
                    
                    goingleft = false;
                    goingright = true;
                }
            }
            else
            {
                Debug.Log("GOING RIGHT.....");
                boss2.transform.position = Vector2.MoveTowards(boss2.transform.position, rightpoint, movementspeed * Time.deltaTime);
                if (boss2.transform.position == rightpoint)
                {
                    goingright = false;
                    goingleft = true;
                }
            }


        }

      

	}

	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	

	}

	
}
