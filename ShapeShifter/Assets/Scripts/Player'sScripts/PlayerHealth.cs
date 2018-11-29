using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    
	public float maxHealth;
	public float currentHealth;
    private AnimatorController animator;
    private PlayerMovement player;
    private SelectForm select;
    private MeleeAttack MAattack;
    private Aimming AimAttack;
    private float hurtTime = 1.0f;
    SceneTransition changescene;

    public Image currentHPBar;
    public Text HPText;
    private ShakeControl Cam;
    
	// Use this for initialization
	void Start () {
        Cam = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeControl>();
		currentHealth = maxHealth;
		player = gameObject.GetComponent<PlayerMovement> ();
        animator = gameObject.GetComponent<AnimatorController>();
        select = gameObject.GetComponent<SelectForm>();
        MAattack = gameObject.GetComponentInChildren<MeleeAttack>();
        AimAttack = gameObject.GetComponentInChildren<Aimming>();
        UpdateHealthBar();

        if (changescene != null)
        {
            changescene = GameObject.Find("SceneManager").GetComponent<SceneTransition>();
        }
        
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
          

			animator.MainAnimator.SetTrigger ("Dies");
			animator.KnightAnimator.SetTrigger("Die");
            animator.MageAnimator.SetTrigger("Die");
            animator.ArcherAnimator.SetTrigger("Die");
            animator.MainAnimator.SetBool("isJumping", false);
            animator.MainAnimator.SetBool("isFalling", false);
            Destroy(gameObject, 2.0f);
            player.rb.velocity = new Vector2(0f, 0f);
            MAattack.enabled = false;
            select.enabled = false;
            player.enabled = false;
            AimAttack.enabled = false;

            changescene.LoadScene("Game Over");
        }

	}

    

	void FixedUpdate() {
		//Debug.Log(currentHealth);
		UpdateHealthBar();
	}

    public void UpdateHealthBar()
    {
        float ratio = currentHealth / maxHealth;
        if (currentHPBar != null)
        {
            currentHPBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        }
       
        /*
        if (currentHealth > 60)
        {
            currentHPBar.color = new Color32(27, 188, 48, 255);
        }
        if (currentHealth <= 60 && currentHealth > 30)
        {
            currentHPBar.color = new Color32(188, 141, 88, 255);
        }

        if (currentHealth <= 30 && currentHealth > 0)
        {
            currentHPBar.color = new Color32(188, 44, 28, 255);
        }
        */
        
    }

	public void TakeDamage(float dam){
        

        if (IsDead()==false) {
            
            currentHealth -= dam;
            Debug.Log(currentHealth);
			StartCoroutine(HurtBlinker(hurtTime));
			Audio.PlaySound ("PlayerHurt");
            Cam.ShakeCamera(.3f);
            //gameObject.GetComponent<Animation> ().Play ("Hurt");


        }

        UpdateHealthBar();
	}
	 
	public void addHealth(int Health){
		currentHealth += Health;
		if (currentHealth > 100)
			currentHealth = 100;
	}

	IEnumerator HurtBlinker(float hurtTime){

        //int enemyLayer = LayerMask.NameToLayer ("Enemy");
        //int playerLayer = LayerMask.NameToLayer ("Player");
        //Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer);

        animator.MainAnimator.SetLayerWeight (1, 1f);
        animator.KnightAnimator.SetLayerWeight (1, 1f);
        animator.MageAnimator.SetLayerWeight(1, 1f);
        animator.ArcherAnimator.SetLayerWeight(1, 1f);
        yield return new WaitForSeconds(hurtTime);

        //Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer, false);

        animator.MainAnimator.SetLayerWeight (1, 0f);
        animator.KnightAnimator.SetLayerWeight (1, 0f);
        animator.MageAnimator.SetLayerWeight(1, 0f);
        animator.ArcherAnimator.SetLayerWeight(1, 0f);
    }

    public bool IsDead()
    {
        if (currentHealth > 0)
            return false;
        else
            return true;
    }



}
