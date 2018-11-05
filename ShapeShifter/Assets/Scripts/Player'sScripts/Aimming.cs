using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimming : MonoBehaviour {


	public float RotateOffset;
	public GameObject projectile;
    public SelectForm Form;
	public Transform shotPoint;
	public int ManaCost;

	private float timeBtwShots;
	public float startTimeBtwShots;

	private Mana pMana;
	private PlayerController player;
    public Animator animator;
    private ShakeControl Cam;
    private Ammo ammo;

    void Start() {
        Form = gameObject.GetComponentInParent<SelectForm>();
        player = gameObject.GetComponent<PlayerController> ();
		pMana = gameObject.GetComponentInParent<Mana> ();
        ammo = gameObject.GetComponentInParent<Ammo>();
        Cam = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeControl>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // subtracting the position of the player from the mouse position.
                                                                                                       //difference.Normalize (); // normalizing the vector. Meaning that all the sum of the vector will be equal to 1.

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //convert angle to degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + RotateOffset);

        if (Form.PlayerSelect == 3)
        {
            if (timeBtwShots <= 0 && (pMana.currentMana >= ManaCost)
                && Input.GetMouseButtonDown(0))
            {
                Audio.PlaySound("Flame");
                Cam.ShakeCamera(.3f);
                animator.SetBool("isAttacking", true);
                Invoke("Shoot", .15f);
                timeBtwShots = startTimeBtwShots;
                pMana.UseMana(ManaCost);
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
                animator.SetBool("isAttacking", false);
            }
        }
        else if (Form.PlayerSelect == 4)
        {
            if (timeBtwShots <= 0 && ammo.CurrentAmmo > 0
                && Input.GetMouseButtonDown(0))
            {
                Audio.PlaySound("BowShoot");
                Cam.ShakeCamera(.3f);
                animator.SetBool("isAttacking", true);
                Invoke("Shoot", .15f);
                timeBtwShots = startTimeBtwShots;
                ammo.ShootAmmo();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
                animator.SetBool("isAttacking", false);
            }
        }
    }

    public void Shoot()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
    }




}

	

