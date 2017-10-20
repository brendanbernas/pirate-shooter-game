using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserShipCollision : MonoBehaviour {

	[SerializeField]
	private GameObject explosion;

	private AudioSource explosionAudio;

	void Start(){
		explosionAudio = this.gameObject.GetComponent<AudioSource> ();
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag.Equals("ice"))
		{
			//lose life
			TakeDamage(3);
		}
		else if(other.gameObject.tag.Equals("RedPirate"))
		{
			Debug.Log("Red pirate hit");
			Instantiate (explosion).GetComponent<Transform> ().position =
				other.GetComponent<Transform> ().position;
			//play explosion sound
			TakeDamage(10);

			other.gameObject.GetComponent<RedPirateController> ().ResetMovePosition ();
		}
		else if(other.gameObject.tag.Equals("GreyPirate"))
		{
			Debug.Log("Grey pirate hit");
			Instantiate (explosion).GetComponent<Transform> ().position =
				other.GetComponent<Transform> ().position;
			TakeDamage (5);
			//play explosion sound

			other.gameObject.GetComponent<GreyShipController> ().ResetMovePosition ();
		}
		else if(other.gameObject.tag.Equals("cannonball"))
		{
			Debug.Log("cannonball hit");

			GameObject smallExplosion = Instantiate (explosion);
			smallExplosion.GetComponent<Transform> ().position =
				other.GetComponent<Transform> ().position;
			smallExplosion.GetComponent<Transform>().localScale = smallExplosion.GetComponent<Transform>().localScale / 2;
			Destroy (other.gameObject);
			TakeDamage (3);
		}
		else if(other.gameObject.tag.Equals("Chest")){
			//play the coin pick up noise
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<ChestController> ().ResetMovePosition ();
			Points.Instance.Amount += 300;
		}
	}

	private void TakeDamage(int amount){
		Life.Instance.Amount -= amount;
		explosionAudio.Play ();
	}


}
