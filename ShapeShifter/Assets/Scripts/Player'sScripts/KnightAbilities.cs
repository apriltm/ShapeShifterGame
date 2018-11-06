using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAbilities : MonoBehaviour {

    [SerializeField]
    public Animator knightAnimator;
    [SerializeField]
    public PlayerHealth playerHealth;

    public Rigidbody2D playerRigidbody;
    public PlayerController playerController;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update() {
        Block();
        Dash();
    }
    /*
     * run on some key click
     * Things it needs to do:
     * change animation to the knight block
     * block incoming damage
     * either slow movement speed or stop him completely
     * 
     * on key release go back to some other animation ( knight idle maybe)
     * 
     * depending on how its implemented, it might need to check if we're currently in knight form
     * 
     * if(isBlocking)
     *  reduce damage
     *  set block animation
     */

    void Block()
    {
        // Set animator to trigger
        if (Input.GetButton("Block"))
        {
            Debug.Log("Is Blocking");
            knightAnimator.SetBool("isBlocking", true);
            playerHealth.isBlocking = true;
        }
        else
        {
            knightAnimator.SetBool("isBlocking", false);
            playerHealth.isBlocking = false;
        }
    }
    


    /*
     * on quick double tap in either left or right direction
     * move quickly in that direction for a set amount of space
     * any enemies hit will take some damage and be knocked back a bit
     * 
     * needs to change to some animation, maybe blocking animation for a bit
     */
    int buttonCount = 0;
    float buttonTimer = 0.5f;

    void Dash() {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (playerController.facingRight == true)
            {
                // dashTimer += Time.deltaTime * 3;
                playerRigidbody.AddForce(Vector3.right * 50);

            }
        }
        /*
        if (dashTimer > .5f)
        {
            canIDash = false;
            dashCooldown = true;
        }
        if (dashTimer < .5f && dashCooldown == false)
        {
            canIDash = true;
        }
        if (dashTimer <= 0)
        {
            dashCooldown = false;
        }
        */

    }
    /*
    if (Input.anyKeyDown) {
        if(buttonTimer > 0 && buttonCount == 1) {
            playerRigidbody.position += new Vector2(playerRigidbody.velocity.x * Time.deltaTime, 0.1f);
        }
        else {
            buttonTimer = 0.5f;
            buttonCount += 1;
        }
    }
    if (buttonTimer > 0) {
        buttonTimer -= 1 * Time.deltaTime;
    }
    else {
        buttonCount = 0;
    }
    */
}
