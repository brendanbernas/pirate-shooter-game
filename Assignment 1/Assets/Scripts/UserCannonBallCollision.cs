/*
 * Name:UserCannonBallCollision.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour of user cannonball collisions
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCannonBallCollision : MonoBehaviour {

	[SerializeField]
	private GameObject explosion;

	private AudioSource coinAudio;

	//getting coin sound audio
	void Start(){
		coinAudio = this.gameObject.GetComponent<AudioSource> ();
	}

	//triggers different behaviour based on collision
	public void OnTriggerEnter2D(Collider2D other){
		//red pirate collision causes explosion and red pirate to reset
		if(other.gameObject.tag.Equals("RedPirate"))
		{
			AddPoints (50);
			CauseExplosion (other);
			other.gameObject.GetComponent<RedPirateController> ().ResetMovePosition ();
		}
		//grey pirate collision causes explosion and grey pirate to reset
		else if(other.gameObject.tag.Equals("GreyPirate"))
		{
			AddPoints (30);
			CauseExplosion (other);
			other.gameObject.GetComponent<GreyShipController> ().ResetMovePosition ();
		}
		//no other behaviour (only collides with red and grey pirate)
	}

	//adds points
	private void AddPoints(int amount){
		Points.Instance.Amount += amount;
	}

	//creates explosion where the game object is located
	private void CauseExplosion(Collider2D other){
		//must let the sound play before you can delete the object, found from:
		//https://forum.unity.com/threads/prefabs-not-playing-audio-solved.485859/#post-3174334

		//starting coin audio playing
		coinAudio.Play();

		//get position of collided object and put explosion there
		Instantiate (explosion).GetComponent<Transform> ().position =
			other.GetComponent<Transform> ().position;
		//hiding the object
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		//disable the 2D collider, otherwise the invisible object will continue to generate events
		this.gameObject.GetComponent<Collider2D> ().enabled = false;

		//allows the game to wait for 0.681s so the audio 
		StartCoroutine ("DestroyMe");
	}

	IEnumerator DestroyMe()
	{
		//sound clip is 0.681s long
		yield return new WaitForSeconds (0.681f);
		Destroy (this.gameObject);
	}
}
