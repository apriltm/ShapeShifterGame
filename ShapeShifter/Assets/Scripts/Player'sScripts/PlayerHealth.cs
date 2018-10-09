using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	private PlayerController player;

    public Image currentHPBar;
    public Text HPText;

	// Use this for initialization
	void Start () {
		
		currentHealth = maxHealth;
		player = gameObject.GetComponent<PlayerController> ();
        UpdateHealthBar();
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			player.animator.SetTrigger ("Dies");
			 
			player.enabled = false;
			Destroy (gameObject, 3.0f);

		}

	}

    

	void FixedUpdate() {
		
	}

    public void UpdateHealthBar()
    {
        float ratio = currentHealth / maxHealth;
        currentHPBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HPText.text = currentHealth.ToString();

        if (currentHealth <= 60)
        {
            currentHPBar.color = new Color32(188, 141, 88, 255);
        }

        if (currentHealth <= 30)
        {
            currentHPBar.color = new Color32(188, 44, 28, 255);
        }
    }

	public void TakeDamage(int dam){

		

		if (currentHealth > 0) {
            currentHealth -= dam;
            Debug.Log(currentHealth);
            player.animator.SetTrigger ("Damaged");
			Audio.PlaySound ("PlayerHurt");
			//gameObject.GetComponent<Animation> ().Play ("Hurt");


		}

        UpdateHealthBar();
	}
	 

}
