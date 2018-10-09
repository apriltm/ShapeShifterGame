using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

	public static AudioClip PlayerHurt, PlayerMove, PlayerAttack,EnemyAttack, enemyHurt, PickUp, lvlUP, Jumping, Shift;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

		PlayerHurt = Resources.Load<AudioClip> ("PlayerHurt");
		PlayerMove = Resources.Load<AudioClip> ("PlayerMove");
		PlayerAttack = Resources.Load<AudioClip> ("playerAttack");
		EnemyAttack = Resources.Load<AudioClip> ("EnemyAttack");
		enemyHurt = Resources.Load<AudioClip> ("EnemyHurt");
		PickUp = Resources.Load<AudioClip> ("PickUp");
		lvlUP = Resources.Load<AudioClip> ("lvlUP");
		Jumping = Resources.Load<AudioClip> ("Jumping");
		Shift = Resources.Load<AudioClip> ("Shift");
		audioSrc = GetComponent<AudioSource> ();

	}
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound ( string clip){

		switch(clip) {
		case "PlayerHurt":
			audioSrc.PlayOneShot (PlayerHurt);
			break;
		case "PlayerMove":
			audioSrc.PlayOneShot (PlayerMove);
			break;
		case "PlayerAttack":
			audioSrc.PlayOneShot (PlayerAttack);
			break;
		case "EnemyAttack":
			audioSrc.PlayOneShot (EnemyAttack);
			break;
		case "EnemyHurt":
			audioSrc.PlayOneShot (enemyHurt);
			break;
		case "PickUp":
			audioSrc.PlayOneShot (PickUp);
			break;
		case "lvlUP":
			audioSrc.PlayOneShot (lvlUP);
			break;
		case "Jumping":
			audioSrc.PlayOneShot (Jumping);
			break;
		case "Shift":
			audioSrc.PlayOneShot (Shift);
			break;
	}
}


}
