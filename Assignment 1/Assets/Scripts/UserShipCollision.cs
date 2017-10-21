/*
 * Name:UserShipCollision.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour of user ship collisions
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserShipCollision : MonoBehaviour {

	[SerializeField]
	private GameObject explosion;

	private AudioSource explosionAudio;

	//getting audio component from game object for later use
	void Start(){
		explosionAudio = this.gameObject.GetComponent<AudioSource> ();
	}

	//triggers different behaviour based on game object collided with
	public void OnTriggerEnter2D(Collider2D other){
		//lose 3 life if hit by ice
		//TakeDamage(x) triggers UI and plays explosion sound
		if(other.gameObject.tag.Equals("ice"))
			TakeDamage(3);
		//lose 10 life if hit by red pirate
		else if(other.gameObject.tag.Equals("RedPirate"))
		{
			//create explosion where red pirate is located
			Instantiate (explosion).GetComponent<Transform> ().position =
				other.GetComponent<Transform> ().position;
			TakeDamage(10);
			//reset red pirate using its public method
			other.gameObject.GetComponent<RedPirateController> ().ResetMovePosition ();
		}
		//lose 5 life if hit by grey pirate
		else if(other.gameObject.tag.Equals("GreyPirate"))
		{
			//create explosion where grey pirate is located
			Instantiate (explosion).GetComponent<Transform> ().position =
				other.GetComponent<Transform> ().position;
			TakeDamage (5);
			//reset grey pirate using its public method
			other.gameObject.GetComponent<GreyShipController> ().ResetMovePosition ();
		}
		//lose 3 life if his by enemy cannonball
		else if(other.gameObject.tag.Equals("cannonball"))
		{
			//create explosion where cannon ball is located
			//this explosion is half the size of regular explosions
			GameObject smallExplosion = Instantiate (explosion);
			smallExplosion.GetComponent<Transform> ().position =
				other.GetComponent<Transform> ().position;
			smallExplosion.GetComponent<Transform>().localScale = smallExplosion.GetComponent<Transform>().localScale / 2;
			//removes the cannonball object from the game space
			Destroy (other.gameObject);
			TakeDamage (3);
		}
		//gain points and plays noise when touching chest
		else if(other.gameObject.tag.Equals("Chest")){
			//play the coin pick up noise
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<ChestController> ().ResetMovePosition ();
			Points.Instance.Amount += 300;
		}
	}

	//called to take damage, accesses singleton class Life
	private void TakeDamage(int amount){
		Life.Instance.Amount -= amount;
		//play explosion noise
		explosionAudio.Play ();
	}


}
