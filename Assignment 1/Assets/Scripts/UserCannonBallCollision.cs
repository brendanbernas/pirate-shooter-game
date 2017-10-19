using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCannonBallCollision : MonoBehaviour {

	[SerializeField]
	private GameObject explosion;

	private AudioSource coinAudio;

	void Start(){
		coinAudio = this.gameObject.GetComponent<AudioSource> ();
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag.Equals("RedPirate"))
		{
			AddPoints (50);
			CauseExplosion (other);
			other.gameObject.GetComponent<RedPirateController> ().ResetMovePosition ();
		}
		else if(other.gameObject.tag.Equals("GreyPirate"))
		{
			AddPoints (30);
			CauseExplosion (other);
			other.gameObject.GetComponent<GreyShipController> ().ResetMovePosition ();
		}
	}

	private void AddPoints(int amount){
		Points.Instance.Amount += amount;
	}

	private void CauseExplosion(Collider2D other){
		//must let the sound play before you can delete the object, found from:
		//https://forum.unity.com/threads/prefabs-not-playing-audio-solved.485859/#post-3174334

		coinAudio.Play();
		Instantiate (explosion).GetComponent<Transform> ().position =
			other.GetComponent<Transform> ().position;
		//hiding the object
		this.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 0;
		//disable the 2D collider, otherwise the invisible object will continue to generate events while on layer 0
		this.gameObject.GetComponent<Collider2D> ().enabled = false;
		StartCoroutine ("DestroyMe");
	}

	IEnumerator DestroyMe()
	{
		//sound clip is 0.681s long
		yield return new WaitForSeconds (0.681f);
		Destroy (this.gameObject);
	}
}
