/*
 * Name:GreyShipController.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour of grey pirate game objects that it is attached to
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyShipController : MonoBehaviour {

	[SerializeField]
	private float startX = 0;
	[SerializeField]
	private float endX = 100;
	[SerializeField]
	private float startY = 0;
	[SerializeField]
	private float endY = 100;
	[SerializeField]
	private float speed = -1;
	[SerializeField]
	private GameObject cannonball;

	private float speedBackup;

	private Transform _transform;
	private Vector2 movePosition;
	private bool hasShot = false;


	//getting transform component
	void Start () {
		_transform = this.gameObject.GetComponent<Transform> ();
		//must backup speed since we modify its value through other functions
		//we use it to restore the speed when it is reset
		speedBackup = speed;
		//reset position once the game starts
		ResetMovePosition ();
	}

	//move the grey pirate with every frame
	void Update () {
		movePosition += new Vector2 (speed, 0);

		//endX is where the grey ship will start shooting
		if (movePosition.x < endX) {
			//if it has already shot, it will not shoot again
			if (hasShot) {
				//if it has shot already, give it time to leave the scene and then reset
				StartCoroutine (WaitAndReset (3f));
			} else {
				speed = 0;
				//start hovering (and shooting)
				StartCoroutine ("Hover");
			}
		}
		//updating position
		_transform.position = movePosition;
	}

	//"respawning" game object
	public void ResetMovePosition(){
		//must reset the speed to the speed it had before
		speed = speedBackup;
		//stopping the hovering if it has been hovering
		StopCoroutine("Hover");
		//move it to random position
		movePosition = new Vector2 (startX + Random.Range(0, 10), Random.Range (startY, endY));
		//reseting value so it may shoot again
		hasShot = false;
	}

	//once called will hover (move right and left) and shoot its cannons
	IEnumerator Hover(){
		speed = 0.05f;
		yield return new WaitForSeconds (0.1f);
		bool forward = true;
		int i = 0;
		//moves back/forth 5 times
		while (i <= 5) {
			i++;
			//moving forward
			if (forward) {
				speed = 0.015f;
				forward = false;
			} else {
				//once it is at the peak of its forward hover position, it will shoot its cannons with this function
				ShootCannons ();
				speed = -0.015f;
				forward = true;
			}
			yield return new WaitForSeconds (1f);
		}
		//after moving back and forth , it will move backward out of the camera view
		speed = -0.015f;
		hasShot = true;
	}

	//give object time to move backward out of the camera view and "respawn" it
	IEnumerator WaitAndReset(float amount){
		yield return new WaitForSeconds (amount);
		ResetMovePosition ();
	}

	//spawns two cannonballs, one shooting up, one shooting down
	private void ShootCannons(){
		//use cannonball object and set its position of the spawner (grey pirate)
		cannonball.GetComponent<CannonBallController> ().spawner = this.gameObject;
		//make this cannonball going in up and slightly forward direction and instantiate it
		cannonball.GetComponent<CannonBallController> ().direction = new Vector2(0.1f, 1f);
		Instantiate (cannonball);

		//make this cannon going in down and slightly forward direction and instantiate its
		cannonball.GetComponent<CannonBallController> ().direction = new Vector2(0.1f, -1f);
		Instantiate (cannonball);
	}
}
