using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public Animator MyAnimator { get; private set; }

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;



    [SerializeField]
	public int maxHealth;
    public int currentHealth;

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }


	// Use this for initialization
	public virtual void Start () {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeDirection() {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    



	//public abstract IEnumerator TakeDamage (int damage);
    
       /* currentHealth -= damage;
        if(!IsDead){
			MyAnimator.SetTrigger ("Damaged");
        } else {
			MyAnimator.SetTrigger ("Die");
			yield return null;
        }*/
    
    

	/*public virtual void OnTriggerEnter2D(Collider2D col){
		if (col.tag = "Enemy_sword") {
			StartCoroutine (TakeDamage ());
		}
	}*/
}
