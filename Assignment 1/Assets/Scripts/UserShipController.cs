/*
 * Name:UserShipController.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour of user ship movement
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserShipController : MonoBehaviour {
	
	[SerializeField]
	private float upperYBound = 1;
	[SerializeField]
	private float lowerYBound = -1;
	[SerializeField]
	private GameObject cannonball;
	[SerializeField]
	private UIController ui;

	private Rigidbody2D shipRb;
	private Transform shipTransform;
	private bool cannonReady = true;

	//gets RigidBody2D component for later use
	//gets UI component to update UI later (for cannonball reload)
	void Start () {
		shipRb = this.gameObject.GetComponent<Rigidbody2D> ();
		shipTransform = this.gameObject.GetComponent<Transform> ();
		ui = ui.GetComponent<UIController> ();
	}

	//uses physics so FixedUpdate() is used
	void FixedUpdate(){
		float force = 4.0f;
		float userInputHorizontal = Input.GetAxis ("Horizontal");
		float userInputFire = Input.GetAxis ("Jump");

		bool passedMaxSpeed = false;
		int rotationAmount = 60;

		//Must regulate the speed of the user ship
		//modified code from: http://answers.unity3d.com/questions/265810/limiting-rigidbody-speed.html
		//regulate the speed of the ship, if it is too fast create a flag
		float maxSpeed = 5f;
		if(shipRb.velocity.magnitude > maxSpeed)
		{
			passedMaxSpeed = true;
		}


		//if ship too high, turn ship down, if ship too low turn ship up
		float forceBackFactor = 4f;
		//turn ship down if too high on y axis
		if (shipTransform.position.y > upperYBound) {
			shipRb.AddForce (Vector2.down * (force * forceBackFactor));
			if(!passedMaxSpeed)
				shipRb.MoveRotation (shipRb.rotation - (rotationAmount * forceBackFactor) * Time.fixedDeltaTime);
			return;
			//return to disable other controls
		}
		//turn ship up if too low on y axis
		else if (shipTransform.position.y < lowerYBound) {
			shipRb.AddForce (Vector2.up * (force * forceBackFactor));
			if(!passedMaxSpeed)
				shipRb.MoveRotation (shipRb.rotation + (rotationAmount * forceBackFactor) * Time.fixedDeltaTime);
			return;
			//return to disable other controls
		}

		//rotation found from: https://docs.unity3d.com/ScriptReference/Rigidbody.MoveRotation.html

		//if user press right arrow key or d, rotate and move ship down
		if (userInputHorizontal > 0) {
				
			shipRb.AddForce (Vector2.down * force);
			if(!passedMaxSpeed)
				shipRb.MoveRotation (shipRb.rotation - rotationAmount * Time.fixedDeltaTime);
		}

		//if user press left arrow key or a, rotate and move ship up
		else if (userInputHorizontal < 0){
			shipRb.AddForce (Vector2.up * force);
			if(!passedMaxSpeed)
				shipRb.MoveRotation (shipRb.rotation + rotationAmount * Time.fixedDeltaTime);
		}
			
		//check flag, if too fast regulate speed (see line 50)
		if(passedMaxSpeed)
			shipRb.velocity = shipRb.velocity.normalized * maxSpeed;

		//if user presses space bar and cannonReady == true create cannonball
		if (userInputFire > 0 && cannonReady) {
			//start 3s cooldown
			StartCoroutine ("CannonCooldown");
			//instantiate our cannonball prefab
			//movement and collision defined in those scripts
			Instantiate (cannonball).GetComponent<UserCannonBallController>().spawner = this.gameObject;

		}
			
	}

	//gives 3s firing cooldown
	IEnumerator CannonCooldown(){
		//updating ui and flag to show not ready
		ui.ShowFireStatus (false);
		cannonReady = false;
		//wait 3s
		yield return new WaitForSeconds (3f);
		//updating ui and flag to show ready
		cannonReady = true;
		ui.ShowFireStatus (true);
	}
}
