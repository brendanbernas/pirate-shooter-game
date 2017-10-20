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

	void Start () {
		_transform = this.gameObject.GetComponent<Transform> ();
		speedBackup = speed;
		ResetMovePosition ();
	}

	// Update is called once per frame
	void Update () {
		movePosition += new Vector2 (speed, 0);

		if (movePosition.x < endX) {
			//if it has already shot, it will not shoot again
			if (hasShot) {
				StartCoroutine (WaitAndReset (3f));
			} else {
				speed = 0;
				//start hovering (and shooting)
				StartCoroutine ("Hover");
			}
		}
		_transform.position = movePosition;
	}

	public void ResetMovePosition(){
		//must reset the speed to the speed it had before
		speed = speedBackup;
		//stopping the hovering
		StopCoroutine("Hover");
		movePosition = new Vector2 (startX + Random.Range(0, 10), Random.Range (startY, endY));
		hasShot = false;
	}

	IEnumerator Hover(){
		speed = 0.05f;
		yield return new WaitForSeconds (0.1f);
		bool forward = true;
		int i = 0;
		//moves back/forth 5 times
		while (i <= 5) {
			i++;
			if (forward) {
				speed = 0.015f;
				forward = false;
			} else {
				ShootCannons ();
				speed = -0.015f;
				forward = true;
			}
			yield return new WaitForSeconds (1f);
		}
		//after moving back and forth , it will move back
		speed = -0.015f;
		hasShot = true;
	}

	IEnumerator WaitAndReset(float amount){
		yield return new WaitForSeconds (amount);
		ResetMovePosition ();
	}

	private void ShootCannons(){
		//spawns two cannonballs, one shooting up, one shooting down
		cannonball.GetComponent<CannonBallController> ().spawner = this.gameObject;
		cannonball.GetComponent<CannonBallController> ().direction = new Vector2(0.1f, 1f);
		Instantiate (cannonball);

		cannonball.GetComponent<CannonBallController> ().direction = new Vector2(0.1f, -1f);
		Instantiate (cannonball);
	}
}
