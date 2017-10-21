/*
 * Name:UserCannonBallController.cs
 * By: Brendan Bernas
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour of user cannonball movement
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCannonBallController : MonoBehaviour {

	public GameObject spawner;
	private Transform objTrans;

	//when cannonball is instantiated, it will rotate the same way as the spawner (user ship)
	void Start () {
		//set rotate to spawner
		Rigidbody2D spawnerRb = spawner.GetComponent<Rigidbody2D>();
		Rigidbody2D objRb = this.gameObject.GetComponent<Rigidbody2D> ();
		objTrans = this.gameObject.GetComponent<Transform> ();

		//ignore the collisions between usercannonball and usership
		Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), spawner.GetComponent<Collider2D> ());

		//setting cannonball to same position as spawner (user ship)
		objTrans.position = spawnerRb.position;
		objTrans.Rotate (0, 0, spawnerRb.rotation);

		//gives cannonball 3s to exist before removing it from the game space
		StartCoroutine ("DespawnCount");
	}

	//moving location direction right every frame
	//modified from week 3 slides
	void Update () {
		//local direction right will mean that it moves based on its position
		float force = 0.1f;
		Vector3 worldRightDirection = objTrans.TransformDirection (Vector2.right * force);
		objTrans.localPosition += worldRightDirection;
	}

	//gives 3s for object to exists before deleting it from game space
	public IEnumerator DespawnCount(){
		yield return new WaitForSeconds (3f);
		Destroy (this.gameObject);
	}
}
