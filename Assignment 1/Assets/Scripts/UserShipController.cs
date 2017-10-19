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

	// Use this for initialization
	void Start () {
		shipRb = this.gameObject.GetComponent<Rigidbody2D> ();
		shipTransform = this.gameObject.GetComponent<Transform> ();
		ui = ui.GetComponent<UIController> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float force = 4.0f;
		float userInputHorizontal = Input.GetAxis ("Horizontal");
		float userInputFire = Input.GetAxis ("Jump");

		bool passedMaxSpeed = false;
		int rotationAmount = 60;

		//TODO taken from online unity....
		//regulate the speed of the ship
		float maxSpeed = 5f;
		if(shipRb.velocity.magnitude > maxSpeed)
		{
			passedMaxSpeed = true;
			//keep rotation at same position
		}


		//if ship too high, turn ship down, if ship too low turn ship up
		float forceBackFactor = 4f;
		if (shipTransform.position.y > upperYBound) {
			shipRb.AddForce (Vector2.down * (force * forceBackFactor));
			if(!passedMaxSpeed)
				shipRb.MoveRotation (shipRb.rotation - (rotationAmount * forceBackFactor) * Time.fixedDeltaTime);
			//lose life?
			return;
		}
		else if (shipTransform.position.y < lowerYBound) {
			shipRb.AddForce (Vector2.up * (force * forceBackFactor));
			if(!passedMaxSpeed)
				shipRb.MoveRotation (shipRb.rotation + (rotationAmount * forceBackFactor) * Time.fixedDeltaTime);
			//lose life?
			return;
		}


		if (userInputHorizontal > 0) {
				
			shipRb.AddForce (Vector2.down * force);
			if(!passedMaxSpeed)
				shipRb.MoveRotation (shipRb.rotation - rotationAmount * Time.fixedDeltaTime);
		}
			
		else if (userInputHorizontal < 0){
			shipRb.AddForce (Vector2.up * force);
			if(!passedMaxSpeed)
				shipRb.MoveRotation (shipRb.rotation + rotationAmount * Time.fixedDeltaTime);
		}
			
		if(passedMaxSpeed)
			shipRb.velocity = shipRb.velocity.normalized * maxSpeed;


		if (userInputFire > 0 && cannonReady) {
			StartCoroutine ("CannonCooldown");
			//CannonBallController.Spawn (this.gameObject.GetComponent<Transform>().position);
			Instantiate (cannonball).GetComponent<UserCannonBallController>().spawner = this.gameObject;

		}
			
	}

	IEnumerator CannonCooldown(){
		ui.ShowFireStatus (false);
		cannonReady = false;
		yield return new WaitForSeconds (3f);
		cannonReady = true;
		ui.ShowFireStatus (true);
	}
}
