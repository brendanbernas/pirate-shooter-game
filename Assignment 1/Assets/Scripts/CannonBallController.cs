/*
 * Name:CannonBallController.cs
 * By: Brendan Bernas
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls the behaviour of the cannonball GameObjects this script is attached to
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour {

	public GameObject spawner;
	public Vector2 direction;

	[SerializeField]
	private float speed = 0.03f;
	[SerializeField]
	private float upperYBound = 5.73f;
	[SerializeField]	
	private float lowerYBound = -5.73f;

	private Vector2 trajectory;
	private Transform cannonTransform;


	//changes position of the GameObject to its spawner
	void Start () {
		//position it to the same location of the spawner (grey pirate ship)
		cannonTransform = this.gameObject.GetComponent<Transform>();
		cannonTransform.position = spawner.GetComponent<Transform> ().position;

	}
	
	//moves in direction specified by instatiator (by changing public direction field)
	void Update () {
		Vector2 currPos = cannonTransform.position;
		//if the cannon ball is out of bounds, delete it
		if (currPos.y >= upperYBound || currPos.y <= lowerYBound)
			Destroy (this.gameObject);
		else {
			//move cannon ball
			currPos += direction * speed;
			cannonTransform.position = currPos;
		}
	}


}
