using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
	public float maxHealth;
	public float currentHealth;
	private PlayerController player;
	private float hurtTime = 1.0f;
    public bool isBlocking = false;

    
    public Image currentHPBar;
    public Text HPText;
    
    // Player only takes 75% of damage if in knight form; 25% if he is also blocking. Otherwise, he takes 100% of damage.
    [SerializeField]
    private float damageReductionMultiplier
    {
        get
        {
            if (player.PlayerSelect == 2)
            {
                if (isBlocking)
                {
                    return 0.25f;
                }
                return 0.50f;
            }
            return 1.0f;
        }
    }
    
	// Use this for initialization
	void Start () {
		
		currentHealth = maxHealth;
		player = gameObject.GetComponent<PlayerController> ();
        UpdateHealthBar();
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
            FindObjectOfType<GameManager>().EndGame();
           

			player.animator.SetTrigger ("Dies");
			player.animator2.SetTrigger("Dies");
			player.animator.SetBool("isJumping", false);
            player.animator.SetBool("isFalling", false);
            player.enabled = false;
			Destroy (gameObject, 3.0f);

		}

	}

    

	void FixedUpdate() {
		//Debug.Log(currentHealth);
		UpdateHealthBar();
	}

    public void UpdateHealthBar()
    {
        
        float ratio = currentHealth / maxHealth;
        currentHPBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HPText.text = currentHealth.ToString();

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

	public void TakeDamage(float damage){

		if (currentHealth > 0) {
            currentHealth -= (damage * damageReductionMultiplier);
            Debug.Log(currentHealth);
			StartCoroutine(HurtBlinker(hurtTime));
			Audio.PlaySound ("PlayerHurt");
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

		player.animator.SetLayerWeight (1, 1f);
		player.animator2.SetLayerWeight (1, 1f);
		yield return new WaitForSeconds(hurtTime);

		//Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer, false);

		player.animator.SetLayerWeight (1, 0f);
		player.animator2.SetLayerWeight (1, 0f);
	}

}
